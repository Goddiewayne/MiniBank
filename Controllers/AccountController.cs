using Microsoft.AspNetCore.Mvc;
using MiniBank.Core.Handlers;
using MiniBank.Entities;
using MiniBank.Models;
using MiniBank.Persistence;

namespace MiniBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly MiniBankDbContext _db;
        public AccountController(MiniBankDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("topupaccount")]
        public async Task<ActionResult<BaseResponse>> TopUpAccount([FromForm] TopUpAccountRequestModel request)
        {
            var response = new BaseResponse();

            var customerAccount = _db.CustomerAccounts.FirstOrDefault(x => x.AccountNumber == request.AccountNumber);
            var customerExists = customerAccount != null;
            if (!customerExists) return new BaseResponse(false, "Account Topup failed. Customer profile not found.");
            try
            {
                customerAccount.AvailableBalance += request.Amount;
                customerAccount.BookBalance += request.Amount;
                _db.CustomerAccounts.Update(customerAccount);
                await _db.SaveChangesAsync();
                response = new BaseResponse(true, "Account TopUp successful");
            }
            catch (Exception ex)
            {
                response = new BaseResponse(false, ex.Message);
            };

            return response;
        }

        [HttpPost]
        [Route("fundtransfer")]
        public async Task<ActionResult<BaseResponse>> TransferFund([FromForm] TransferFundRequestModel request)
        {
            var response = new BaseResponse();

            var customerAccount = _db.CustomerAccounts.FirstOrDefault(x => x.AccountNumber == request.SourceAccountNumber);
            var customerExists = customerAccount != null;
            if (!customerExists) return new BaseResponse(false, "Fund transfer failed. Customer profile not found.");
            try
            {
                if (customerAccount.AvailableBalance < request.Amount) return new BaseResponse(false, "Fund transfer failed due to insufficient funds.");
                customerAccount.AvailableBalance -= request.Amount;
                customerAccount.BookBalance -= request.Amount;
                _db.CustomerAccounts.Update(customerAccount);
                await _db.SaveChangesAsync();
                response = new BaseResponse(true, "Fund transfer successful");
            }
            catch (Exception ex)
            {
                response = new BaseResponse(false, ex.Message);
            };

            return response;
        }

    }
}
