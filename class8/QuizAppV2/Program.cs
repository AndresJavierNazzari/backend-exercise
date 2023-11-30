using QuizAppV2;

class Program
{
    static List<Quiz> quizList = new List<Quiz>();

    static void Main()
    {
        Console.WriteLine("Welcome to Quiz Game App !");
        AddDefaultQuizes();

        while(true)
        {
            int choicesQty = Menus.PrintMainMenu();
            int choice = Menus.GetChoice(choicesQty);

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
        if(quizList.Count == 0)
        {
            Console.WriteLine("No quizzes available. Create a quiz first.");
            return;
        }

        Console.WriteLine("Selec a Quizz to start:");
        Game game = new Game();
        game.SelectQuiz(quizList);
    }

    static void AddDefaultQuizes()
    {
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

        quizList.Add(videoGameQuiz);
        quizList.Add(planetsQuiz);

        foreach(Quiz quiz in quizList)
        {
            Console.WriteLine($"Quiz '{quiz.Name}' created successfully.");
        }
        Console.WriteLine();
    }
}
