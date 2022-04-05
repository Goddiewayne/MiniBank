using System.ComponentModel.DataAnnotations;

namespace MiniBank.Models
{
    public class TransferFundRequestModel
    {
        [StringLength(10,ErrorMessage = $"{nameof(SourceAccountNumber)} Invalid account number")]
        public string SourceAccountNumber { get; set; }
        [StringLength(10, ErrorMessage = $"{nameof(RecipientAccountNumber)} Invalid account number")]
        public string RecipientAccountNumber { get; set; }
        [Range(100, 1000000, ErrorMessage = "Amount can only be between 100 .. 1000000")]
        public decimal Amount { get; set; }
    }
}