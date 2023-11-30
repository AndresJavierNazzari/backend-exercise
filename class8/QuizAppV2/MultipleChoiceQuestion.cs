using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAppV2
{
    internal class MultipleChoiceQuestion : Question
    {
        public List<string> Choices { get; set; }
        public int Answer { get; set; }

        public MultipleChoiceQuestion(string questionText, List<string> choices, int answer, int score) : base(questionText, score)
        {
            this.Choices = choices;
            this.Answer = answer;
        }

        public static MultipleChoiceQuestion CreateQuestion()
        {
            string questionText = Menus.EnterProperty("question", "text");
            Console.WriteLine("Enter the anser choices (separate each choice with a coma): ");
            List<string> answerChoices = new List<string>(Console.ReadLine().Split(','));

            Console.WriteLine("These are the answer choices: ");
            for(int i = 0 ; i < answerChoices.Count ; i++)
            {
                Console.WriteLine($"{i + 1} - {answerChoices[i]}");
            }

            int correctAnswer;
            string correctAnswerStr = Menus.EnterProperty("question", "answer");
            while(!int.TryParse(correctAnswerStr, out correctAnswer) || correctAnswer < 1 || correctAnswer > answerChoices.Count)
            {
                Console.WriteLine("Invalid input. Please try again.");
                correctAnswerStr = Menus.EnterProperty("question", "answer");
            }

            int questionScore;
            string questionScoreStr = Menus.EnterProperty("question", "score");
            while(!int.TryParse(questionScoreStr, out questionScore))
            {
                Console.WriteLine("Invalid input. Please try again.");
                questionScoreStr = Menus.EnterProperty("question", "score");
            }

            return new MultipleChoiceQuestion(questionText, answerChoices, correctAnswer, questionScore);
        }
    }
}
