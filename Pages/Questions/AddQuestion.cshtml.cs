using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using stembowl.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace stembowl.Pages
{
    public class AddQuestionModel : PageModel
    {
        public string Message {get; set;}
        QADataAccessLayer QuestionAccessLayer = new QADataAccessLayer();

        [Authorize]
        public void OnGet()
        {
        }
        public ActionResult OnPostSubmit()
        {
            return RedirectToPage("./NewOrder");
        }
    }
}