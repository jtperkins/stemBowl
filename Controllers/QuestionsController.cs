using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using stembowl.Models;    
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

        public QuestionsController(QuestionDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            questions = _context.Questions.Where( e => e.SubmitterID == User.GetUserId()).ToList();
            foreach(var question in questions)
                question.Answers = _context.Answer.Where( e => e.QuestionID == question.QuestionID).ToList();
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
        public ActionResult Create (Question q )
        {
            try
            {
                if (ModelState.IsValid)
                { 
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
            //There -has- to be a better way to do this
            Answer[] answers = _context.Answer.Where(e => e.QuestionID == questionID).ToArray();
            _context.Answer.RemoveRange(answers);
            _context.Questions.Remove( _context.Questions.Where(e => e.QuestionID == questionID).FirstOrDefault());
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult GetAll()
        {
            questions = _context.Questions.ToList();
            return View(questions);
        }
    }
}