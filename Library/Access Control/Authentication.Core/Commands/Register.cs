using System.ComponentModel.DataAnnotations;

namespace Authentication.Core.Commands
{
    public class Register
    {
        [Required]
        public string EmailAddress { get; set; } = string.Empty;
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
