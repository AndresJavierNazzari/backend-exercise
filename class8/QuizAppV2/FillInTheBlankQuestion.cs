using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAppV2
{
    internal class FillInTheBlankQuestion : Question
    {
        public string Answer { get; set; }

        public FillInTheBlankQuestion(string questionText, string answer, int score) : base(questionText, score)
        {
            this.Answer = answer;
        }

        public static FillInTheBlankQuestion CreateQuestion()
        {
            string questionText = Utils.EnterProperty("question", "text");
            string questionAnswer = Utils.EnterProperty("question", "answer");
            string questionScoreStr = Utils.EnterProperty("question", "score");
            int questionScore;

            while(!int.TryParse(questionScoreStr, out questionScore))
            {
                Console.WriteLine("Invalid input. Please try again.");
                questionScoreStr = Utils.EnterProperty("question", "score");
            }

            return new FillInTheBlankQuestion(questionText, questionAnswer, questionScore);
        }
    }
}
