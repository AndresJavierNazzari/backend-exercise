namespace QuizzApp
{
    internal class Question
    {
        public string QuestionText { get; set; }
        public int Score { get; set; }

        public Question(string questionText, int score) { 
            this.QuestionText = questionText;
            this.Score = score;
        }

    }
}
