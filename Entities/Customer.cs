using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniBank.Entities
{
    [Table("Customers")]
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public long CustomerAccountId { get; set; }
        public long ImageId { get; set; }
        public Image Image { get; set; }
        public IList<CustomerAccount> CustomerAccounts { get; set; } = new List<CustomerAccount>();
    }
}