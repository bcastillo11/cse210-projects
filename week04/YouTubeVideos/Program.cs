using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        Video video1 = new Video("Germany 7 - 1 Brazil | World Cup 2014 Highlights", "FIFA", 858);
        video1.AddComment(new Comment("Lucas", "I still can’t believe this actually happened."));
        video1.AddComment(new Comment("Maria", "As a Brazilian, this still hurts"));
        video1.AddComment(new Comment("Thomas", "Germany was unstoppable that day."));
        video1.AddComment(new Comment("Elena", "One of the most shocking games in football history."));

        Video video2 = new Video("Interstellar - Official Trailer", "Warner Bros. Pictures", 150);
        video2.AddComment(new Comment("Daniel", "This trailer gave me chills!"));
        video2.AddComment(new Comment("Sophie", "Hans Zimmer’s soundtrack is just epic."));
        video2.AddComment(new Comment("Mark", "One of the best sci-fi movies of all time."));
        video2.AddComment(new Comment("Olivia", "Even the trailer feels like a masterpiece."));

        Video video3 = new Video("How to Change a Spark Plug | Easy Tutorial", "CarFix Garage", 588);
        video3.AddComment(new Comment("Jake", "Thanks! I just saved money doing it myself."));
        video3.AddComment(new Comment("Emily", "Super clear explanation, great job."));
        video3.AddComment(new Comment("Robert", "Do you have a video for changing brake pads?"));
        video3.AddComment(new Comment("Anna", "This was exactly what I needed today."));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        Console.WriteLine(new String('-', 50));
        foreach (Video v in videos)
        {
            v.Display();
        }
    }
}