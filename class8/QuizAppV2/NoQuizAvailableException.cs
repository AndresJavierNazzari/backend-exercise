namespace QuizAppV2
{
    internal class NoQuizAvailableException : Exception
    {
        public NoQuizAvailableException() : base() { }
        public NoQuizAvailableException(string message) : base(message) { }

    }
}
