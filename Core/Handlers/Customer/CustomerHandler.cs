using MiniBank.Entities;
using MiniBank.Models;
using MiniBank.Persistence;

namespace MiniBank.Core.Handlers
{
    public class CustomerHandler
    {
        private readonly MiniBankDbContext _db;
        public CustomerHandler(MiniBankDbContext db)
        {
            _db = db;
        }
        //public async Task<BaseResponse> RegisterCustomer(CreateCustomerRequestModel request)
        //{
           
        //}
    }

}
