using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniBank.Entities
{
    [Table("CustomerAccounts")]
    public class CustomerAccount : BaseEntity
    {
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public decimal AvailableBalance { get; set; }
        public decimal BookBalance { get; set; }
    }
}