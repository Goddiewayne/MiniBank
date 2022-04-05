using MiniBank.Models;
using MiniBank.Persistence;

namespace MiniBank.Core.Handlers
{
    public class AccountHandler
    {
        private readonly MiniBankDbContext _db;
        public AccountHandler(MiniBankDbContext db)
        {
            _db = db;
        }
        //public async Task<BaseResponse> TopUpAccount(TopUpAccountRequestModel request)
        //{
           
        //}
        public static string GetNewAccountNumber()
        {
            string startWith = "30";
            Random generator = new();
            string r = generator.Next(0, 99999999).ToString("D8");
            return startWith + r; ;
        }
    }
}
