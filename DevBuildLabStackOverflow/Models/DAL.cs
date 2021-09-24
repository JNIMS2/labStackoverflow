using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using Dapper;


namespace DevBuildLabStackOverflow.Models
{
    public class DAL
    {
        public static string CurrentUser = null;
        public static MySqlConnection DB;

        //need to add CRUD functions
        //R-have a get all questions to see what the questions are (do i need one for categories? maybe...)
        //C-need a create question
        //D-delete question--only username's
        //D-close question--admins change the status
        //U-upate question--only username's

        
        //read all questions in questions table:
        public static List<Question> GetAllQuestions()
        {
            return DB.GetAll<Question>().ToList();
        }

        public static Question GetQuestion(int id)
        {
            return DB.Get<Question>(id);
        }
        //insert into questions table:
        //need a form for this: and update
        public static void InsertQuestion(Question ques)
        {
            ques.username = DAL.CurrentUser;
            DB.Insert(ques);
        }

        //update question:
        //need a form for this in the view and controller:
        public static void UpdateQuestion(Question ques)
        {
            ques.username = DAL.CurrentUser;
            DB.Update(ques);
        }

        //delete question:
        public static void DeleteQuestion(int id)
        {
            //requires an instance
            Question ques = new Question() { id = id };
            DB.Delete(ques);
        }
        //then need the same for answers:
        //Create answer for a question-C
        //Read all answers for a question-R
        public static QuestionAnswers GetAllForQuestion(int thequesId)
        {
            var keyvalues = new { quesid = thequesId };
            string sql = "select * from answers where answerid = @quesid";
            QuestionAnswers qa = new QuestionAnswers();
            qa.ans = DB.Query<Answer>(sql, keyvalues).ToList();
            qa.ques = DAL.GetQuestion(thequesId);
            return qa;
        }

        public static Answer GetAnswer(int id)
        {
            return DB.Get<Answer>(id);
        }
        //Create answer for a question-C
        public static void InsertAnswer(Answer ans)
        {
             ans.username = DAL.CurrentUser;
            DB.Insert(ans);
        }
        //Update answer for a question(own answer)-U
        public static void UpdateAnswer(Answer ans)
        {
           ans.username = DAL.CurrentUser;
            DB.Update(ans);
        }
        //Delete answer for a question(own answer)-D
        //also requires an instance
        public static void DeleteAnswer(int id)
        {
            Answer ans = new Answer() { id = id };
            DB.Delete(ans);
        }

        //search answers
        public static List<Answer> SearchAnswers(string str)
        {
            var keyvaluepair = new { search = $"%{str}%" };
            string sql = "select * from porduct where detail like @search ";
            return DB.Query<Answer>(sql, keyvaluepair).ToList();
        }


    }
}
