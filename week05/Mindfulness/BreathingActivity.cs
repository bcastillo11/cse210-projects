public class BreathingActivity : Activity
{
    public int Breathinglapse { get; private set; } = 6;

    public BreathingActivity() : base()
    {
        Name = "Breathing";
        Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
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

        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            TextAnimation("Breathe in... ");
            ShowCountDown(Breathinglapse);

            Console.WriteLine("");

            TextAnimation("Breath out... ");
            ShowCountDown(Breathinglapse);

            Console.WriteLine("");
            Console.WriteLine("");
        }

        DisplayEndingMessage();
    }
}