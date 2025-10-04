public class Activity
{

    public string Name { get; protected set; }

    public string Description { get; protected set; }

    public int Duration { get; protected set; }

    public Activity()
    {
        Name = "";
        Description = "";
        Duration = 30;
    }

    public int DisplayStartingMessage()
    {
        TextAnimation($"Welcome to the {Name} Activity.");
        Console.WriteLine("");
        TextAnimation(Description);

        int entry = 0;
        do
        {
            try
            {
                Console.WriteLine("");
                TextAnimation("How long, in seconds, would you like for your session? ");
                string input = Console.ReadLine();

                entry = int.Parse(input);

                break;
            }
            catch (FormatException)
            {
                Console.Write($"{Environment.NewLine}Invalid entry. Try Again.");
            }

        } while (true);

        return entry;
    }

    public void DisplayEndingMessage()
    {
        TextAnimation("Well Done!");
        Console.WriteLine("");
        ShowLoadingAnimation();
        TextAnimation($"You Have completed another {Duration} seconds of the {Name} Activity.");
        Console.WriteLine("");
        ShowLoadingAnimation();
    }

    protected void ShowLoadingAnimation()
    {
        
        DateTime endTime = DateTime.Now.AddSeconds(4);

        Console.CursorVisible = false;
        while (DateTime.Now < endTime)
        {
            Console.Write("■"); ;
            Thread.Sleep(300);
        }
        Console.CursorVisible = true;

        Console.Write($"\r" + new string(' ', Console.WindowWidth) + "\r");
        Console.WriteLine("");
    }

    protected void ShowCountDown(int lapse)
    {
        DateTime endTime = DateTime.Now.AddSeconds(lapse);

        int i = lapse;

        Console.CursorVisible = false;
        while (DateTime.Now < endTime)
        {
            Console.Write($"{i}"); ;
            Thread.Sleep(1000);

            Console.Write($"\b \b");
            i -= 1;
        }
        Console.CursorVisible = true;
    }

    protected void TextAnimation(string text)
    {
        Console.CursorVisible = false;
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(15);
        }
        Console.CursorVisible = true;
    }

    protected void ShowSpinningWheel(int seconds)
    {
        string[] frames = { "⠋", "⠙", "⠹", "⠸", "⠼", "⠴", "⠦", "⠧", "⠇", "⠏" };

        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        Console.CursorVisible = false;

        while (DateTime.Now < endTime)
        {
            Console.Write($"{frames[index]}");
            Thread.Sleep(200);
            Console.Write($"\b \b");
            index = (index + 1) % frames.Length;
        }

        Console.CursorVisible = true;
    }
        
}