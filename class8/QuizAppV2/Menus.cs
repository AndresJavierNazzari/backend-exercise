using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizAppV2
{
    internal class Menus
    {
        public static int PrintMainMenu()
        {
            Console.WriteLine("Please choose an option: ");
            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. Create a Quiz");
            Console.WriteLine("3. Exit");

            int choicesQty = 3;
            return choicesQty;
        }

        public static int PrintChooseTypeQuestionMenu()
        {
            Console.WriteLine("Please choose the type of question: ");
            Console.WriteLine("1. Multiple Choice");
            Console.WriteLine("2. Fill in the Blank");

            int choicesQty = 2;
            return choicesQty;
        }

        public static int GetChoice(int cantChoices)
        {
            int choice;
            while(!int.TryParse(Console.ReadKey().KeyChar.ToString(), out choice) || (choice < 1 || choice > cantChoices))
            {
                Console.WriteLine($"Invalid input. Please enter a number between 1 and {cantChoices}.");
                Console.Write($"Enter your choice (1-{cantChoices}): ");
            }

            return choice;
        }

        public static dynamic EnterProperty(string entity, string prop)
        {
            Console.Write($"Enter the {prop} of the {entity}: ");
            string? property = Console.ReadLine();

            while(string.IsNullOrEmpty(property))
            {
                Console.Write($"The {prop}  of the {entity} can not be empty!");
                Console.Write($"Enter the {prop} of the {entity} again: ");
                property = Console.ReadLine();
            }
            return property;
        }
    }
}
