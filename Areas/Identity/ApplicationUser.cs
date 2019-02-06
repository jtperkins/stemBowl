using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using stembowl.Models;

namespace stembowl.Areas.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("Team")]
        public string TeamID {get; set;}
        public Team Team {get; set;}
    }
}