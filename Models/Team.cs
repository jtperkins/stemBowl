using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using stembowl.Areas.Identity;

namespace stembowl.Models
{
    public class Team
    {
        public Team()
        {
        }
        public string TeamName {get; set;}
        public string TeamID {get; set;}
        public ICollection<TeamAnswers> Answered { get; set;}
        public ICollection<Question> Unanswered {get; set;}
        public ICollection<ApplicationUser> TeamMembers { get; set;}
        [ForeignKey("Leader")]
        public string LeaderID {get; set;}
        public ApplicationUser Leader { get; set;}
        public int score;
    }
}