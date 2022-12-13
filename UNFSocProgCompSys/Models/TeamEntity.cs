using System;
using System.ComponentModel.DataAnnotations;


namespace UNFSocProgCompSys.Models
{
    public class TeamEntity
    {
        public Guid Id { get; set; }

        //A team name is required for every team.
        [Required]
        public string Name { get; set; }

        //Stores the number of members in the team. Each team will have at least one member.
        public int NumberOfMembers { get; set; }

        public bool LookingForMembers { get; set; }

        //Variable to store an array of users who are members of the team
        //public Users[] Members[] { get; set; }

    }
}
