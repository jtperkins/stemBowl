using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using stembowl.Models;
using Microsoft.EntityFrameworkCore;

namespace stembowl.Areas.Identity.Pages.Account.Manage
{
    public class TeamManagmentModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private QuestionDbContext _questionDbContext;
        private readonly ILogger<TeamManagmentModel> _logger;

        public TeamManagmentModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<TeamManagmentModel> logger,
            QuestionDbContext questionDbContext)
        {
            _questionDbContext = questionDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public DisplayModel Display {get; set;}

        [TempData]
        public string StatusMessage { get; set; }

       public class DisplayModel
       {
           [Display]
           public string TeamName {get; set;}
           [Display(Name = "Team Lead")]
           public string TeamLead {get; set;}
       }

        public async Task<IActionResult> OnGetAsync()
        {
            //Need to make TeamMembers function for this to work

            var user = await _userManager.GetUserAsync(User);
            var team = _questionDbContext.Teams
                .Include(e=> e.TeamMembers)
                .Include(e => e.Leader)
                .Where(e => e.TeamMembers.Contains(user))
                //.Where(e => e.Leader == user)
                .FirstOrDefault();

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }else if(user.Id == team.LeaderID)
            {
                return RedirectToPage("AddMember");
            }
            else if(team != null)
            {
                var a = team.Leader.UserName;
                Display = new DisplayModel{
                    TeamLead = team.Leader.UserName,
                    TeamName = team.TeamName
                };
                return Page();
            }
            return RedirectToPage("CreateTeam");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            
           
            //await _signInManager.RefreshSignInAsync(user);
            //_logger.LogInformation("User changed their role successfully.");
            //StatusMessage = "You are now registered and can submit questions";

            return RedirectToPage();
        }
    }
}
