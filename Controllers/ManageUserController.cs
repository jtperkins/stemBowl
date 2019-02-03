// From https://nbarbettini.gitbooks.io/little-asp-net-core-book/content/chapters/security-and-identity/authorization-with-roles.html

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using stembowl.Models;
using Microsoft.EntityFrameworkCore;

namespace stembowl.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManageUsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ManageUsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var admins = (await _userManager
                .GetUsersInRoleAsync("Admin"))
                .ToArray();
            var faculty = (await _userManager
                .GetUsersInRoleAsync("Faculty"))
                .ToArray();

            var everyone = await _userManager.Users
                .ToArrayAsync();

            var model = new ManageUsersViewModel
            {
                Administrators = admins,
                Faculty = faculty,
                Everyone = everyone
            };

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> AddRole(String userID, String role)
        {
            var user = await _userManager.FindByIdAsync(userID);
            await _userManager.AddToRoleAsync(user, role);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> RemoveRole(String userID, String role)
        {
            var user = await _userManager.FindByIdAsync(userID);
            await _userManager.RemoveFromRoleAsync(user, role);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteUser(String userID)
        {
            var user = await _userManager.FindByIdAsync(userID);
            await _userManager.DeleteAsync(user);

            return RedirectToAction("Index");
        }
    }
}