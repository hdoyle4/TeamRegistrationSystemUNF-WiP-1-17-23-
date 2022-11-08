using System.ComponentModel.DataAnnotations;

namespace UNFSocProgCompSys.Models
{
    public class Competition
    {
        [Key]
        public Guid CompetitionID { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage ="The competition needs to have a name.")]
        public string CompetitionName { get; set; }

        [Required(ErrorMessage = "The competition needs to have a date.")]
        public DateTime CompetitionDate { get; set; }

        [Required(ErrorMessage = "The competition needs to have a start time.")]
        public DateTime CompetitionStartTime { get; set; }

        [Required(ErrorMessage = "The competition needs to have a ending time.")]
        public DateTime CompetitionEndTime { get; set; }

        public string CompetitionLocation { get; set; } = "TBD";

        public string? CompetitionDescription { get; set; }

        //Minimum team size?

        [Required(ErrorMessage = "The competition needs to have a maximum team size.")]
        public int CompetitionMaxTeamSize { get; set; }
    } //End of public class Competition
}     //End of namespace UNFSoCProgCompSys
