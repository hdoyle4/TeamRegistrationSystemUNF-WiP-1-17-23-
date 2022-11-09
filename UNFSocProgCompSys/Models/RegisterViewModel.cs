using System.ComponentModel.DataAnnotations;

namespace UNFSocProgCompSys.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(25, ErrorMessage ="Password Can't be longer Than 25 characters or shorter than 6",MinimumLength =6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
        public string? ReturnUrl { get; set; }

        [Required]
        public string Username { get; set; }
    }
}
