using Microsoft.AspNetCore.Mvc;
using MiniBank.Core.Handlers;
using MiniBank.Entities;
using MiniBank.Models;
using MiniBank.Persistence;

namespace MiniBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly MiniBankDbContext _db;
        public CustomerController(MiniBankDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("register")]
        public async Task<BaseResponse> RegisterCustomer([FromForm] CreateCustomerRequestModel request)
        {
            var response = new BaseResponse();
            var customerExists = _db.Customers.Any(x => x.EmailAddress == request.EmailAddress || x.PhoneNumber == request.PhoneNumber);
            if (customerExists) return new BaseResponse(false, "Customer profile already exist.");
            var firstName = request.FirstName.Trim();
            var lastName = request.LastName.Trim();

            long size = request.Image.Length;
            var file = request.Image;

            try
            {
                string name = file.FileName.Replace(@"\\\\", @"\\");

                if (file.Length > 0)
                {
                    var memoryStream = new MemoryStream();

                    try
                    {
                        await file.CopyToAsync(memoryStream);

                        // Upload check if less than 2mb!
                        if (memoryStream.Length < 2097152)
                        {
                            var image = new Image()
                            {
                                FileName = Path.GetFileName(name),
                                FileSize = memoryStream.Length,
                                FileContent = memoryStream.ToArray(),
                                DateCreated = DateTime.Now
                            };

                            var customer = new Customer
                            {
                                FirstName = request.FirstName,
                                LastName = request.LastName,
                                PhoneNumber = request.PhoneNumber,
                                EmailAddress = request.EmailAddress,
                                Image = image,
                            };
                            string accountNumber;
                            bool accountNumberExist;
                            do
                            {
                                accountNumber = AccountHandler.GetNewAccountNumber();
                                accountNumberExist = _db.CustomerAccounts.Any(x => x.AccountNumber == accountNumber);
                            } while (accountNumberExist == true);

                            var customerAccount = new CustomerAccount
                            {
                                AccountName = $"{firstName} {lastName}",
                                AccountNumber = accountNumber,
                                AvailableBalance = 0,
                                BookBalance = 0
                            };

                            customer.CustomerAccounts.Add(customerAccount);

                            _db.Customers.Add(customer);
                            await _db.SaveChangesAsync();

                            response = new BaseResponse(true, "Customer Profiling Successful");
                        }
                        else
                        {
                            response = new BaseResponse(false, "Image file size is larger than 2mb");
                        }
                    }
                    finally
                    {
                        memoryStream.Close();
                        memoryStream.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                response = new BaseResponse(false, ex.Message);
            };
            return response;
        }

    }
}
