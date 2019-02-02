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

namespace stembowl.Controllers
{
    [Authorize]        
    public class QuestionsController : Controller
    { 
        List<Question> questions {get; set;}

        QuestionDbContext _context;
        UserManager<IdentityUser> _userContext;

        public QuestionsController(QuestionDbContext context, UserManager<IdentityUser> userManager)
        {
            _userContext = userManager;
            _context = context;
        }

        public ActionResult Index()
        {

            questions = _context.Questions
                .Where( e => e.SubmitterID == User.GetUserId())
                .Include(e => e.Answers).ToList();
            
            return View(questions);
        }

        [HttpGet]
        public ActionResult Create(string userID)
        {
            var q = new Question();
            q.SubmitterID = userID;
            return View(q);
        }

        [HttpPost]
        public ActionResult Create (Question q, string textShortAnswer, string TrueFalse, string textA, bool boolA, string textB, bool boolB, string textC, bool boolC, string textD, bool boolD)
        {
            try
            {
                if (ModelState.IsValid)
                { 
                    if(q.Format == Format.TrueFalse)
                        q.Answers.Add(new Answer() { Text="", Correct=bool.Parse(TrueFalse)});
                    if(q.Format == Format.ShortAnswer)
                        q.Answers.Add(new Answer() { Text=textShortAnswer, Correct=true});
                    if(q.Format == Format.MultipleChoice)
                    {
                        q.Answers.Add(new Answer() { Text=textA, Correct=boolA });
                        q.Answers.Add(new Answer() { Text=textB, Correct=boolB });
                        q.Answers.Add(new Answer() { Text=textC, Correct=boolC });
                        q.Answers.Add(new Answer() { Text=textD, Correct=boolD });
                    }
                    _context.Questions.Add(q);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }

            return View();
        }

        public ActionResult Delete(int questionID)
        {
            var questions = _context.Questions
                .Where(e => e.QuestionID == questionID)
                .Include(e => e.Answers)
                .ToList();
            _context.RemoveRange(questions);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult GetAll()
        {
            questions = _context.Questions
                .Include(e => e.Answers)
                .ToList();
            foreach(var question in questions)
                question.SubmitterID = _userContext.Users.Where(e => e.Id == question.SubmitterID).FirstOrDefault()?.Email;
            return View(questions);
        }

    }
}