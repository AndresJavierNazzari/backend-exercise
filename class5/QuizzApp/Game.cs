namespace QuizzApp
{
    internal class Game
    {
        public void StartGame(Quiz quiz)
        {
            int totalScore = 0;

            foreach(var question in quiz.Questions)
            {
                ShowQuestion(question);    
                totalScore += GetUserInputAndScore(question);
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
