using System.ComponentModel.DataAnnotations;

namespace UNFSocProgCompSys.Models
{
    public class ProfileView
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string School { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string ProgLang { get; set; }
        [Required]
        public string ClassesTaken { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Password Can't be longer Than 25 characters or shorter than 6", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } 

        public User[] UserProfile { get; set; }
    }
}
