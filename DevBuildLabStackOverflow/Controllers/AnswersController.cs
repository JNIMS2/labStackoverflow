using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevBuildLabStackOverflow.Models;
using MySql.Data.MySqlClient;

namespace DevBuildLabStackOverflow.Controllers
{
    public class AnswersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult ListAnswers(int quesid)
        {
            QuestionAnswers ans = DAL.GetAllForQuestion(quesid);
                return View(ans);
        }

        //upvote
        public IActionResult IncreaseUpvotes(int id)
        {
            Answer ans = DAL.GetAnswer(id);
            ans.upvotes++;
            return Redirect($"/Answer/ListAnswers?quesid={ans.questionId}");
        }

        public IActionResult DecreaseUpvotes(int id)
        {
            Answer ans = DAL.GetAnswer(id);
            ans.upvotes--;
            DAL.UpdateAnswer(ans);
            return Redirect($"/Answer/ListAnswers?quesid={ans.questionId}");



        }
    }
}
