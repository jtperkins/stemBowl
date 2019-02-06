using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using stembowl.Areas.Identity;

namespace stembowl.Models
{
    public class TeamMembers
    {

        public TeamMembers() {}

        public TeamMembers(ApplicationUser applicationUser, Team team)
        {
            TeamMember = applicationUser;
            TeamMemberID =  applicationUser.Id;
            
            Team = team;
            TeamID = team.TeamID;

        }
        public string TeamMembersID {get; set;}
        [ForeignKey("Team")]
        public string TeamID {get; set;}
        public Team Team {get; set;}

        [ForeignKey("TeamMember")]
        public string TeamMemberID {get; set;}
        public ApplicationUser TeamMember {get; set;}

    }
}