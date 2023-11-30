using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAppV2
{
    internal class Quiz
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Question> Questions { get; set; }

        public Quiz(string name, string description, List<Question> questions)
        {
            this.Name = name;
            this.Description = description;
            this.Questions = questions;
        }

        public static Quiz CreateQuizz()
        {
            string quizNmae = Menus.EnterProperty("quiz", "name");
            string quizDescription = Menus.EnterProperty("quiz", "description");

            List<Question> questions = new List<Question>();
            bool addMoreQuestions = true;

            while(addMoreQuestions)
            {
                int choicesQty = Menus.PrintChooseTypeQuestionMenu();
                int choice = Menus.GetChoice(choicesQty);

                switch(choice)
                {
                    case 1:
                        questions.Add(MultipleChoiceQuestion.CreateQuestion());

                        Console.Write("Do you want to add more questions? (y/N): ");
                        addMoreQuestions = Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase);
                        break;
                    case 2:
                        questions.Add(FillInTheBlankQuestion.CreateQuestion());

                        Console.Write("Do you want to add more questions? (y/N): ");
                        addMoreQuestions = Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Choice. Please try again.");
                        break;
                }
            }

            Quiz newQuiz = new Quiz(quizNmae, quizDescription, questions);
            Console.WriteLine($"Quiz '{quizNmae}' was created!!");

            return newQuiz;
        }
    }
}
