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
    }
}
