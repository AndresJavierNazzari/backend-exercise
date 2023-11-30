using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAppV2
{
    internal class Question
    {
        public string QuestionText { get; set; }
        public int Score { get; set; }

        public Question(string questionText, int score)
        {
            this.QuestionText = questionText;
            this.Score = score;
        }
    }
}
