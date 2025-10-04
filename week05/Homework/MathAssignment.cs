public class MathAssignment : Assignment
{
    private string _textBookSection;
    private string _problems;

    public MathAssignment(string studentName, string topic, string textBookSection, string problems) : base(studentName, topic)
    {
        _textBookSection = textBookSection;
        _problems = problems;
    }

    public MathAssignment() : base()
    {
        _textBookSection = "Not provided";
        _problems = "Not provided";
    }

    public string GetHomeWorkList()
    {
        return $"{_textBookSection} Problems {_problems}";
    }
}