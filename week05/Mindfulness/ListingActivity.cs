public class ListingActivity : Activity
{
    public int Count { get; protected set; }
    public List<string> Prompt { get; } = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base()
    {
        Name = "Listing";
        Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public List<string> GetListFromUser(int duration)
    {

        List<string> userList = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("► ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                userList.Add(input);
            }
        }

        return userList;
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(0, Prompt.Count);
        return Prompt[index];
    }

    public void Run()
    {
        ShowLoadingAnimation();
        Console.Clear();
        
        Duration = DisplayStartingMessage();

        Console.Clear();

        TextAnimation("Get ready... ");
        Console.WriteLine("");
        ShowLoadingAnimation();

        Console.WriteLine("");
        TextAnimation($"List as many responses as you can to the following promt:{Environment.NewLine}  ---- {GetRandomPrompt()} ----{Environment.NewLine}You may begin in: ");
        ShowCountDown(5);

        Console.WriteLine("");

        List<string> userResponses = GetListFromUser(Duration);

        Console.WriteLine($"\nYou listed {userResponses.Count} items!");

        DisplayEndingMessage();
    }


}