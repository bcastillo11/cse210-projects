using System;


class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the Resumes Project.");
        Resume myResume = new Resume();

        Job job1 = new Job();
        Job job2 = new Job();

        job1._company = "Microsoft";
        job1._jobTitle = "Software engineer";
        job1._startYear = 2019;
        job1._endYear = 2022;

        job2._company = "Apple";
        job2._jobTitle = "Manager";
        job2._startYear = 2022;
        job2._endYear = 2023;

        myResume._name = "Byron Castillo";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}