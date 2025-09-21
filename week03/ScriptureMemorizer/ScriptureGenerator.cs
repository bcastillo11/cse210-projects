using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

public class ScriptureGenerator
{
    private List<Scripture> _scriptures = new List<Scripture>();

    public ScriptureGenerator()
    {
        LoadScriptures();
    }

    private void LoadScriptures()
    {
        _scriptures.Clear();
        string pattern = @"(?<Book>(\d+\s+)?[A-Z][a-z]+(?:\s+[A-Z][a-z]+)*)\s*(?<Chapter>\d+)\s*:\s*(?<Verse>\d+)(\s*-\s*(?<EndVerse>\d+))?";
        Regex regex = new Regex(pattern);

        string fileName = "ScripturesFile.txt";
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        if (!File.Exists(path)) path = Path.GetFullPath(fileName);
        if (!File.Exists(path)) { Console.WriteLine("Archivo no encontrado."); return; }

        using (StreamReader sr = new StreamReader(path))
        {
            string line;
            Reference reference = null;
            string scriptureText = "";

            while ((line = sr.ReadLine()) != null)
            {
                if (regex.IsMatch(line))
                {
                    if (!string.IsNullOrWhiteSpace(scriptureText) && reference != null)
                    {
                        _scriptures.Add(new Scripture(reference, scriptureText.Trim()));
                        scriptureText = "";
                    }

                    Match match = regex.Match(line);
                    int endVerse;
                    if (int.TryParse(match.Groups["EndVerse"].Value, out endVerse))
                    {
                        reference = new Reference(match.Groups["Book"].Value, int.Parse(match.Groups["Chapter"].Value), int.Parse(match.Groups["Verse"].Value), endVerse);
                    }
                    else
                    {
                        reference = new Reference(match.Groups["Book"].Value, int.Parse(match.Groups["Chapter"].Value), int.Parse(match.Groups["Verse"].Value));
                    }
                }
                else if (!line.StartsWith("---"))
                {
                    scriptureText += line + " ";
                }
            }

            if (!string.IsNullOrWhiteSpace(scriptureText) && reference != null)
            {
                _scriptures.Add(new Scripture(reference, scriptureText.Trim()));
            }
        }
    }

    public Scripture GetRandomScripture()
    {

        if (_scriptures.Count == 0) return null;

        Random random = new Random();

        int pos = random.Next(0, _scriptures.Count);

        return _scriptures[pos];
    }

    public void DisplayAll()
    {
        foreach (Scripture s in _scriptures)
        {
            Console.WriteLine(s.GetDisplayText());
            Console.WriteLine("----------------------------------");
        }
    }
}