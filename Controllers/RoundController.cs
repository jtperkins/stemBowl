using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stembowl.Models;
using Microsoft.EntityFrameworkCore;    
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Authentication;
using System.Security.Principal;
using Shared.Web.MvcExtensions;
using stembowl.Areas.Identity;

namespace stembowl.Controllers
{
    [Authorize(Roles = "Grader, Admin")]
    public class RoundController : Controller
    { 
        IEnumerable<Question> questions {get; set;}
        QuestionDbContext _context;
        UserManager<ApplicationUser> _userContext;

        public RoundController(QuestionDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userContext = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var qId = _context.TeamAnswers.Select(tm => tm.QuestionID).Distinct();
            questions = _context.Questions.Where(e => qId.Contains(e.QuestionID));
            return View(questions);            
        }

        [HttpGet]
        public IActionResult Add()
        {
            questions = _context.Questions
                .Include(q => q.Answers)
                .ToList();
            return View(questions);            
        }

        [HttpPost]
        public IActionResult Add(IEnumerable<string> questions)
        {
            //Todo : add to all applicable teamanswers
            return RedirectToAction("Index");            
        }
    
    }
}