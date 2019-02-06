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
namespace stembowl.Areas.Identity.Pages.Account.Manage
{
    public class CreateTeamModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private QuestionDbContext _questionDbContext;
        private readonly ILogger<TeamManagmentModel> _logger;

        public CreateTeamModel(
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
        public InputModel Input {get; set;}

        [TempData]
        public string StatusMessage { get; set; }

       public class InputModel
       {
           [Display(Name ="Team Name")]
           [Required]
           public string TeamName {get; set;}

       }


        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var user = await _userManager.GetUserAsync(User);
            var alreadyUsed = _questionDbContext.Teams
                .Where(e => e.TeamName.ToLower() == Input.TeamName.ToLower())
                .FirstOrDefault();
            if(user == null)
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            if(alreadyUsed != null)
            {
                ModelState.AddModelError(string.Empty, $"Team {alreadyUsed.TeamName} already exists.");
                return Page();
            }
            
            Team team = new Team(Input.TeamName, user);

            //_questionDbContext.Teams.Add(team);
            //await _questionDbContext.SaveChangesAsync();

            user.Team = team;
            user.TeamID = team.TeamID;
            await _userManager.UpdateAsync(user);

            return Page();
        }
    }
}