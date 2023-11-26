using QuizzApp;
class Program
{
    static void Main()
    {
        // Crear instancias de preguntas
        MultipleChoiceQuestion question1 = new MultipleChoiceQuestion("What is the capital of France?", new List<string> { "London", "Paris", "Berlin" }, 2, 10);
        FillInTheBlankQuestion question2 = new FillInTheBlankQuestion("The largest planet in our solar system is __.", "Jupiter", 15);

        // Crear instancias de un cuestionario
        List<Question> questions = new List<Question> { question1, question2 };
        Quiz quiz = new Quiz("General Knowledge", "A quiz to test your general knowledge", questions);
        Quiz quiz2 = new Quiz("General Planets", "A quiz to test your general planets", questions);

        List<Quiz> quizList = [quiz, quiz2];

        // Crear una instancia de Game y comenzar el juego
        Game game = new Game();
        game.SelectQuiz(quizList);
    }
}
