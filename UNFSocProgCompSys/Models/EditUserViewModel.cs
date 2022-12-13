using System.ComponentModel.DataAnnotations;

namespace UNFSocProgCompSys.Models
{
    public class EditUserViewModel
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

        public User[] UserProfile { get; set; }

    }
}
