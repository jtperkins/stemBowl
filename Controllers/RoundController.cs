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
        public IActionResult Add(IEnumerable<int> questions)
        {
            //Todo : add to all applicable teamanswers
            var answers = _context.Questions.Where(e => questions.Any(q => q == e.QuestionID));
            var teams = _context.Teams;

            var teamAnswers = new List<TeamAnswers>();
            foreach (var team in teams)
            {
                foreach (var answer in answers)
                {
                    var teamAnswer = new TeamAnswers(answer, team);
                    if(!_context.TeamAnswers.Contains(teamAnswer))
                    {
                        teamAnswers.Add(teamAnswer);
                    }
                }
            }

            _context.TeamAnswers.AddRange(teamAnswers);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int questionID)
        {
            var questions = _context.TeamAnswers
                .Where(e => e.QuestionID == questionID)
                .ToList();
            _context.RemoveRange(questions);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
   
    }
}