namespace QuizAppV2
{
    internal class InvalidInputException : Exception
    {
        public InvalidInputException() : base() { }
        public InvalidInputException(string message) : base(message) { }
    }
}
