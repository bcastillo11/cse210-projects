using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"{_date}");
        Console.WriteLine($"{_prompt}");
        Console.WriteLine($"{_entryText}");
    }
}