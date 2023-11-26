namespace QuizzApp
{
    internal class Game
    {
        public void SelectQuiz(List<Quiz> quizList) 
        {
            Console.WriteLine("List of available quizes: ");
            for (int i = 0; i < quizList.Count; i++)
            {
                Console.WriteLine($"{i+1} - {quizList[i].Name}");
            }
            int choice;
            do
            {
                Console.Write("Enter the number of the quiz you want to play: ");

            } while(!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > quizList.Count);
            Quiz selectedQuiz = quizList[choice - 1];
            StartGame(selectedQuiz);

        }
        
        public void StartGame(Quiz quiz)
        {
            Console.Clear();
            int totalScore = 0;

            foreach(var question in quiz.Questions)
            {
                ShowQuestion(question);    
                totalScore += GetUserInputAndScore(question);
                Console.WriteLine();
            }

            ShowScore(totalScore);
        }

        private static void ShowQuestion(Question question)
        {
            Console.WriteLine($"Question: {question.QuestionText}");

            if(question is MultipleChoiceQuestion mcqQuestion)
            {
                Console.WriteLine("Options: ");
                for (int i =0 ; i<mcqQuestion.Choices.Count ; i++)
                {
                    Console.WriteLine($"{i + 1} - {mcqQuestion.Choices[i]}");
                }
            }
        }

        private static int GetUserInputAndScore(Question question)
        {
            if(question is  MultipleChoiceQuestion mcqQuestion) 
            {
                int userAnswer;
                Console.WriteLine("Enter the number of your answer");
                while(!int.TryParse(Console.ReadLine(), out  userAnswer) || userAnswer < 1 || userAnswer > mcqQuestion.Choices.Count)
                {
                    Console.WriteLine("Please enter a valid answer number");
                    Console.WriteLine("Enter the number of your answer");
                }
                return userAnswer == mcqQuestion.Answer ? question.Score : 0;
            } 
            else if(question is FillInTheBlankQuestion fibQuestion) 
            {
                Console.WriteLine("Enter your answer:");
                string? userAnswer = Console.ReadLine();
                while(string.IsNullOrEmpty(userAnswer))
                {
                    Console.WriteLine("Please enter a valid answer");
                    Console.WriteLine("Enter your answer:");
                    userAnswer = Console.ReadLine();
                }

                return string.Equals(userAnswer.Trim(), fibQuestion.Answer, StringComparison.OrdinalIgnoreCase) ? question.Score : 0;
            };

            return 0;
        }

        private void ShowScore(int score) 
        {
         Console.WriteLine($"Your Score: {score}");
        }
    }

}
