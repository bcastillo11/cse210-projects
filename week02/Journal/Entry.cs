using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"{_date} - {_prompt}");
        Console.WriteLine($"{_entryText}");
    }

    public string DisplayPreview()
    {
        return $"{_date} - {_prompt}";
    }
}