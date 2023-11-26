namespace QuizzApp
{
    internal class Quiz
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Question> Questions { get; set; }

        public Quiz(string name , string description, List<Question> questions ) {
            this.Name = name;
            this.Description = description;
            this.Questions = questions;
        }
    }
}
