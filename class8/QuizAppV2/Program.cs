using QuizAppV2;

class Program
{
    public static List<Quiz> quizList = new List<Quiz>();

    static void Main()
    {
        Console.WriteLine("Welcome to Quiz Game App !");
        Utils.AddDefaultQuizes();

        while(true)
        {
            int choicesQty = Menus.PrintMainMenu();
            int choice = Utils.GetChoice(choicesQty);

            switch(choice)
            {
                case 1:
                    Console.Clear();
                    StartGame();
                    break;
                case 2:
                    Console.Clear();
                    quizList.Add(Quiz.CreateQuizz());
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Exiting the Input Commands Manager...");
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid Choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void StartGame()
    {
        try
        {
            if(quizList.Count == 0)
            {
                throw new NoQuizAvailableException("No quizzes available. Create a quiz first.");
            }

            Console.WriteLine("Selec a Quizz to start:");
            Game game = new Game();
            Quiz selectedQuiz = game.SelectQuiz(quizList);

            game.Start(selectedQuiz);

        } catch(NoQuizAvailableException ex)
        {
            Utils.LogExceptionToFile(ex);
            Console.WriteLine(ex.Message);
        }
    }


}
