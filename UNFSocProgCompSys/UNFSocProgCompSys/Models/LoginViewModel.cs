using System.ComponentModel.DataAnnotations;

namespace UNFSocProgCompSys.Models
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remember Me?")]
        public bool RememberMe { get; set; }
        [Required]
        public string Username { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
