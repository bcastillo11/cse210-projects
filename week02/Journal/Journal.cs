using System;
using System.IO;
using System.Text.RegularExpressions;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry currentEntry in _entries)
        {
            Console.WriteLine(new string('-', 50));
            currentEntry.Display();
            Console.WriteLine(new string('-', 50));
        }
    }

    public bool SaveToFile(string file)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(file))
            {
                foreach (Entry entry in _entries)
                {
                    sw.WriteLine($"DATE: {entry._date}");
                    sw.WriteLine($"PROMPT: {entry._prompt}");
                    sw.WriteLine($"ENTRY: {entry._entryText}");
                    sw.WriteLine(new string('-', 30));
                }
            }

            return true;
        }
        catch (FileNotFoundException)
        {
            return false;
        }
    }

    public void LoadFromFile(string file)
    {

        try
        {
            using (StreamReader sr = new StreamReader(file))
            {
                string line;
                Entry current = null;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("DATE:"))
                    {
                        if (current != null)
                        {
                            _entries.Add(current);
                        }

                        current = new Entry();
                        current._date = line.Replace("DATE:", "").Trim();
                    }
                    else if (line.StartsWith("PROMPT:"))
                    {
                        current._prompt = line.Replace("PROMPT:", "").Trim();
                    }
                    else if (line.StartsWith("ENTRY:"))
                    {
                        string entryString = line.Replace("ENTRY:", "");

                        while ((line = sr.ReadLine()) != null && !line.StartsWith("---"))
                        {
                            entryString = entryString + line + Environment.NewLine;
                        }

                        current._entryText = entryString.Trim();
                    }
                    else if (line.StartsWith("---"))
                    {
                        if (current != null)
                        {
                            _entries.Add(current);
                            current = new Entry();
                        }
                    }
                }

                if (current != null)
                {
                    _entries.Add(current);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found");
        }
        
    }
}