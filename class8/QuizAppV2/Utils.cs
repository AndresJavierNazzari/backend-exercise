using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QuizAppV2 {
    internal class Utils {
        public static bool ContainsRestrictedSymbols(string input) {
            string restrictedSymbols = "()[]{}~\"\'";
            return input.Any(c => restrictedSymbols.Contains(c));

        }

        public static int GetChoice(int cantChoices) {
            int choice;
            while(!int.TryParse(Console.ReadKey().KeyChar.ToString(), out choice) || (choice < 1 || choice > cantChoices)) {
                Console.WriteLine();
                Console.WriteLine($"Invalid input. Please enter a number between 1 and {cantChoices}.");
                Console.Write($"Enter your choice (1-{cantChoices}): ");
            }

            return choice;
        }

        public static dynamic EnterProperty(string entity, string prop) {
            Console.Write($"Enter the {prop} of the {entity}: ");
            string? property = Console.ReadLine();

            while(string.IsNullOrEmpty(property)) {
                Console.Write($"The {prop}  of the {entity} can not be empty!");
                Console.Write($"Enter the {prop} of the {entity} again: ");
                property = Console.ReadLine();
            }
            return property;
        }

        public static void LogExceptionToFile(Exception ex) {
            string logFilePath = "exception_log.txt";
            try {
                string logMessage = $"[{DateTime.Now}] {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}\n";
                File.AppendAllText(logFilePath, logMessage);
            } catch(IOException ioEx) {
                Console.WriteLine($"Error writing to log file: {ioEx.Message}");
            }
        }

        public static void AddDefaultQuizes() {
            MultipleChoiceQuestion vgq1 = new MultipleChoiceQuestion("Who is the main character in the game 'The Legend of Zelda'??", new List<string> { "Link", "Mario", "Zelda" }, 1, 10);
            MultipleChoiceQuestion vgq2 = new MultipleChoiceQuestion("What year was the game 'Super Mario Bros.' first released?", new List<string> { "1983", "1985", "1990" }, 2, 10);
            MultipleChoiceQuestion vgq3 = new MultipleChoiceQuestion("Who developed the game 'Minecraft'?", new List<string> { "Microsoft", "Mojang", "EA Games" }, 2, 10);
            FillInTheBlankQuestion vgq4 = new FillInTheBlankQuestion("The main character in the game 'Assassin's Creed' is named __.", "Ezio", 15);

            MultipleChoiceQuestion pq1 = new MultipleChoiceQuestion("Which planet is known as the 'Red Planet'?", new List<string> { "Earth", "Mars", "Jupiter" }, 2, 10);
            MultipleChoiceQuestion pq2 = new MultipleChoiceQuestion("What is the largest planet in our solar system?", new List<string> { "Venus", "Saturn", "Jupiter" }, 3, 10);
            MultipleChoiceQuestion pq3 = new MultipleChoiceQuestion("How many moons does Earth have?", new List<string> { "1", "2", "0" }, 1, 8);
            FillInTheBlankQuestion pq4 = new FillInTheBlankQuestion("The closest star to Earth is __.", "Sun", 12);
            FillInTheBlankQuestion pq5 = new FillInTheBlankQuestion("The fifth planet from the sun is __.", "Jupiter", 10);

            // Crear instancias de un cuestionario

            List<Question> videoGameQuizQuestions = new List<Question> { vgq1, vgq2, vgq3, vgq4 };
            Quiz videoGameQuiz = new Quiz("Video Games", "A quiz about video games", videoGameQuizQuestions);

            List<Question> planetsQuizQuestions = new List<Question> { pq1, pq2, pq3, pq4, pq5 };
            Quiz planetsQuiz = new Quiz("Planets and Space", "A quiz about planets and space", videoGameQuizQuestions);

            List<Quiz> quizList = Program.quizList;

            quizList.Add(videoGameQuiz);
            quizList.Add(planetsQuiz);

            foreach(Quiz quiz in quizList) {
                Console.WriteLine($"Quiz '{quiz.Name}' created successfully.");
            }
            Console.WriteLine();
        }


    }
}
