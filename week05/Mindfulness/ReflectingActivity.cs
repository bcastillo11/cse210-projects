public class ReflectingActivity : Activity
{
    public List<string> Prompt { get; } = new List<string>{
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."};

    public List<(string question, bool isUsed)> Question { get; } = new List<(string, bool)>
    {
        ("Why was this experience meaningful to you?", false),
        ("Have you ever done anything like this before?", false),
        ("How did you get started?", false),
        ("How did you feel when it was complete?", false),
        ("What made this time different than other times when you were not as successful?", false),
        ("What is your favorite thing about this experience?", false),
        ("What could you learn from this experience that applies to other situations?", false),
        ("What did you learn about yourself through this experience?", false),
        ("How can you keep this experience in mind in the future?", false)
    };

    private int Count { get; set; }

    public ReflectingActivity() : base()
    {
        Name = "Reflecting";
        Description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();

        int promptIndex = random.Next(0, Prompt.Count);

        string ranpPrompt = Prompt[promptIndex];

        return ranpPrompt;
    }

    private string GetRandomQuestion()
    {
        if (AllQUsed()) return null;

        Random random = new Random();

        while (true)
        {
            int index = random.Next(0, Question.Count);

            var (q, used) = Question[index];

            if (!used)
            {
                Question[index] = (q, true);
                return q;
            }
        }

    }

    private bool AllQUsed()
    {

        foreach ((string q, bool used) in Question)
        {
            if (!used)
            {
                return false;
            }
        }

        return true;
    }

    public void Run()
    {
        ShowLoadingAnimation();
        Console.Clear();
        
        Duration = DisplayStartingMessage();;

        Console.Clear();

        TextAnimation("Get ready... ");
        Console.WriteLine("");
        ShowLoadingAnimation();

        TextAnimation($"Consider the following prompt:{Environment.NewLine}  --- {GetRandomPrompt()} ---{Environment.NewLine}When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("");
        TextAnimation($"Now ponder on each of the following questions as they related to this experience.{Environment.NewLine}You may begin in: ");
        ShowCountDown(5);

        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        Console.Clear();
        while (DateTime.Now < endTime)
        {
            if (AllQUsed()) break;

            TextAnimation($"► {GetRandomQuestion()} ");
            ShowSpinningWheel(5);

            Console.WriteLine("");
        }

        Console.WriteLine("");

        DisplayEndingMessage();
    }
}