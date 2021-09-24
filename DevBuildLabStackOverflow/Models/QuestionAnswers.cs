using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DevBuildLabStackOverflow.Models
{
    public class QuestionAnswers
    {
        public Question ques { get; set; }
        public List<Answer> ans { get; set; }
    }
}
