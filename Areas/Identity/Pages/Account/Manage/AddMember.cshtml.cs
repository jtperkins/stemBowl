
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
        public InputModel Input { get; set; }
        [BindProperty]

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Display(Name = "Team Name")]
            public string TeamName {get; set;}
            [Display(Name = "Add a team member")]
            public string AddMember { get; set; }
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

            var userAdd = _userManager.Users.Where(e => e.NormalizedUserName == Input.AddMember.Normalize()).FirstOrDefault();

            if(userAdd != null)
            {
                _questionDbContext.Teams.Where(e => user == e.Leader );
                StatusMessage = userAdd.UserName + " was added to your team!";
                return RedirectToPage();
            }

            var changeRoleResult = await _userManager.AddToRoleAsync(user, "TeamLead");
            if (!changeRoleResult.Succeeded)
            {
                foreach (var error in changeRoleResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }
            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("User changed their role successfully.");
            StatusMessage = "You are now registered and can submit questions";

            return RedirectToPage();
        }
    }
}