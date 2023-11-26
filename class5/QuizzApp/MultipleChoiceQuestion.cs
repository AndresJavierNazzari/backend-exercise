using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzApp
{
    internal class MultipleChoiceQuestion : Question
    {
        public required List<string> Choices {  get; set; }
        public int Answer { get; set; }

        public MultipleChoiceQuestion(string questionText, int score, List<string> choices, int answer) : base (questionText, score)
        {
            this.Choices = choices;
            this.Answer = answer;
        }
    }
}
