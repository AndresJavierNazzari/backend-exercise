using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp
{
    internal class FillInTheBlankQuestion : Question
    {
        public string Answer {  get; set; }

        public FillInTheBlankQuestion(string questionText, string answer, int score) : base(questionText, score) {
            this.Answer = answer;
         }
    }
}
