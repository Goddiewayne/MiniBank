using System.ComponentModel.DataAnnotations;

namespace MiniBank.Models
{
    public class CreateCustomerRequestModel
    {
        [Required]
        [MinLength(2, ErrorMessage = $"{nameof(FirstName)} should have at least 2 characters")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = $"{nameof(FirstName)} should have at least 2 characters")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = $"{nameof(EmailAddress)} Please enter a valid email address")]
        public string EmailAddress { get; set; }
        [Required]
        [Phone(ErrorMessage = $"{nameof(PhoneNumber)} Please enter a valid phone number")]
        public string PhoneNumber { get; set; }
        public IFormFile Image { get; set; }
    }
}