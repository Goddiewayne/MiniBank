using System.ComponentModel.DataAnnotations;

namespace MiniBank.Models
{
    public class TopUpAccountRequestModel
    {
        [StringLength(10,ErrorMessage = $"{nameof(AccountNumber)} Invalid account number")]
        public string AccountNumber { get; set; }
        [Range(100, 1000000, ErrorMessage = "Amount can only be between 100 .. 1000000")]
        public decimal Amount { get; set; }
    }
}