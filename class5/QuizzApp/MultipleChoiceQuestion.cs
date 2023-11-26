namespace QuizzApp;

internal class MultipleChoiceQuestion : Question
{
    public List<string> Choices {  get; set; }
    public int Answer { get; set; }

    public MultipleChoiceQuestion(string questionText,  List<string> choices, int answer, int score) : base (questionText, score)
    {
        this.Choices = choices;
        this.Answer = answer;
    }
}
