
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
    public class AddMemberModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private QuestionDbContext _questionDbContext;
        private readonly ILogger<AddMemberModel> _logger;

        public AddMemberModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AddMemberModel> logger,
            QuestionDbContext questionDbContext)
        {
            _questionDbContext = questionDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public IEnumerable<TeamMembers> Members {get; set;}
        [BindProperty]
        public InputModel Input { get; set; }
        [BindProperty]

        [TempData]
        public string StatusMessage { get; set; }


        public class InputModel
        {
            [Display(Name = "Team Name")]
            public string TeamName {get; set;}
            [Required]
            [EmailAddress]
            [Display(Name = "Add a team member by email")]
            public string AddMember { get; set; }
       }

       public async Task<IActionResult> OnGetAsync()
       {
            var user = await _userManager.GetUserAsync(User);
            var team = _questionDbContext.Teams
                                .Where(e => e.LeaderID == user.Id)
                                .Include(t => t.TeamMembers)
                                .ThenInclude(tm => tm.TeamMember)
                                .FirstOrDefault();
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }else if(team == null)
            {
                return RedirectToPage("CreateTeam");
            }
            Members = team.TeamMembers;

            return Page();
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

            var userAdd = _userManager.Users
                .Where(e => e.NormalizedUserName == Input.AddMember.Normalize())
                .FirstOrDefault();

            if(userAdd != null)
            {
                var team = _questionDbContext.Teams
                    .Where(e => e.LeaderID == user.Id)
                    .Include(t => t.TeamMembers)
                    .FirstOrDefault();
                team.TeamMembers.Add( new TeamMembers(userAdd, team));
                userAdd.TeamID = team.TeamID;
                await _userManager.UpdateAsync(userAdd);
                _questionDbContext.Update(team);
                await _questionDbContext.SaveChangesAsync();

                StatusMessage = userAdd.UserName + " was added to your team!";
                return RedirectToPage();
            }

            
            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("Tried to add an invalid user.");
            ModelState.AddModelError(string.Empty, "No user found with that email");

            return Page();
        }
    }
}