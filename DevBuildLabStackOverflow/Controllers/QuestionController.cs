using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevBuildLabStackOverflow.Models;
using MySql.Data.MySqlClient;

namespace DevBuildLabStackOverflow.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult Index()
        {
            List<Question> ques = DAL.GetAllQuestions();
            return View(ques);
        }

        public IActionResult AddQuestionForm()
        {
            if (DAL.CurrentUser == null)
            {
                return Redirect("/");

            }
            return View();
        }
        [HttpPost]  
        public IActionResult SaveQuestion(Question ques)
        {
            if (DAL.CurrentUser == null)
            {
                return Redirect("/");
            }
            DAL.InsertQuestion(ques);
            return Redirect("/Question");
        }
        //figure out where i want to redirect this to
        public IActionResult DeleteQuestion(int quesid)
        {
            return Redirect("/");
        }


    }
}
