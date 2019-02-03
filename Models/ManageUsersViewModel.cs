using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace stembowl.Models
{
    public class ManageUsersViewModel
    {
        public IdentityUser[] Administrators { get; set; }
        public IdentityUser[] Faculty {get; set;}

        public IdentityUser[] Everyone { get; set;}
    }
}