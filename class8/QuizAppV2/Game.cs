namespace QuizAppV2 {
    internal class Game {
        public Quiz SelectQuiz(List<Quiz> quizList) {
            Console.Clear();

            Console.WriteLine("List of available quizes: ");
            for(int i = 0 ; i < quizList.Count ; i++) {
                Console.WriteLine($"{i + 1} - {quizList[i].Name}");
            }

            int choice;

            while(true) {
                Console.WriteLine("Enter the number of the quiz you want to play: ");
                string? userInput = Console.ReadLine();

                try {
                    if(string.IsNullOrEmpty(userInput)) {
                        throw new InvalidInputException("The quiz cannont be empty.");
                    }
                    if(Utils.ContainsRestrictedSymbols(userInput)) {
                        throw new InvalidInputException("The quiz cannont contains simbols ()[]{}~\"\'.");
                    }
                    if(!int.TryParse(userInput, out choice)) {
                        throw new InvalidInputException("The quiz must be the number of the option.");
                    }
                    if(choice < 1 || choice > quizList.Count) {
                        throw new InvalidInputException($"The quiz must be between 1 and {quizList.Count}.");
                    }

                    Quiz selectedQuiz = quizList[choice - 1];
                    return selectedQuiz;

                } catch(Exception ex) {
                    Utils.LogExceptionToFile(ex);
                    Console.WriteLine(ex.Message);

                } finally {
                    Console.WriteLine("Please enter a valid quiz number.");
                }
            }

        }

        public void Start(Quiz quiz) {
            Console.Clear();
            int totalScore = 0;

            foreach(var question in quiz.Questions) {
                ShowQuestion(question);
                totalScore += GetUserInputAndScore(question);
                Console.WriteLine();
            }

            ShowScore(totalScore);
        }

        private static void ShowQuestion(Question question) {
            Console.WriteLine($"Question: {question.QuestionText}");

            if(question is MultipleChoiceQuestion mcqQuestion) {
                Console.WriteLine("Options: ");
                for(int i = 0 ; i < mcqQuestion.Choices.Count ; i++) {
                    Console.WriteLine($"{i + 1} - {mcqQuestion.Choices[i]}");
                }
            }
        }

        private static int GetUserInputAndScore(Question question) {

            if(question is MultipleChoiceQuestion mcqQuestion) {
                int userAnswer;

                while(true) {
                    Console.WriteLine("Enter the number of your answer: ");
                    string? userInput = Console.ReadLine();

                    try {
                        if(string.IsNullOrEmpty(userInput)) {
                            throw new InvalidInputException("The answer cannont be empty.");
                        }
                        if(Utils.ContainsRestrictedSymbols(userInput)) {
                            throw new InvalidInputException("The answer cannont contains simbols ()[]{}~\"\'.");
                        }
                        if(!int.TryParse(userInput, out userAnswer)) {
                            throw new InvalidInputException("The answer must be the number of the option.");
                        }
                        if(userAnswer < 1 || userAnswer > mcqQuestion.Choices.Count) {
                            throw new InvalidInputException($"The answer must be between 1 and {mcqQuestion.Choices.Count}.");
                        }

                        return userAnswer == mcqQuestion.Answer ? question.Score : 0;
                    } catch(Exception ex) {
                        Utils.LogExceptionToFile(ex);
                        Console.WriteLine(ex.Message);
                    } finally {
                        Console.WriteLine("Please enter a valid answer number");
                    }
                }


            } else if(question is FillInTheBlankQuestion fibQuestion) {
                Console.WriteLine("Enter your answer:");
                string? userAnswer = Console.ReadLine();

                while(true) {
                    try {
                        if(string.IsNullOrEmpty(userAnswer)) {
                            throw new InvalidInputException("The answer cannont be empty...");

                        } else if(Utils.ContainsRestrictedSymbols(userAnswer)) {
                            throw new InvalidInputException("The answer cannont contains simbols ()[]{}~\"\'...");
                        }

                        return string.Equals(userAnswer.Trim(), fibQuestion.Answer, StringComparison.OrdinalIgnoreCase) ? question.Score : 0;

                    } catch(NoQuizAvailableException ex) {
                        Utils.LogExceptionToFile(ex);
                        Console.WriteLine(ex.Message);

                    } catch(InvalidInputException ex) {
                        Utils.LogExceptionToFile(ex);
                        Console.WriteLine(ex.Message);

                    } finally {
                        Console.WriteLine("Please enter a valid answer.");
                    }

                    userAnswer = Console.ReadLine();
                }
            };
            return 0;
        }

        private void ShowScore(int score) {
            Console.WriteLine($"Your Score: {score}");
        }
    }
}
