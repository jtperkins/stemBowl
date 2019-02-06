using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using stembowl.Areas.Identity;


namespace stembowl.Models
{
    public class ManageUsersViewModel
    {
        public ApplicationUser[] Administrators { get; set; }
        public ApplicationUser[] Faculty {get; set;}

        public ApplicationUser[] Everyone { get; set;}
    }
}