using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace UNFSocProgCompSys.Models
{
    public class User : IdentityUser
    { 
        [Key]
        [Required]
        public Guid Id { get; set; }
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

    }
}
