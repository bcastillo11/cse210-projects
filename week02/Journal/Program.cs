using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello World! This is the Journal Project.");
        PromptGenerator prompt = new PromptGenerator();
        Journal myJournal = new Journal();
        Entry newEntry = new Entry();

        Console.WriteLine("Welcome to your Journal.");
        Console.WriteLine("Enter the umber of what you would like to do:");

        while (true)
        {
            Console.WriteLine($"1. New Entry{Environment.NewLine}2. Display Journal{Environment.NewLine}3. Save journal to a new file{Environment.NewLine}4. Load journal from a different file.{Environment.NewLine}5. Exit.");
            Console.Write("Select: ");
            string inputChoice = Console.ReadLine();
            int choice;

            while (!int.TryParse(inputChoice, out choice) || choice < 1 || choice > 5)
            {
                Console.Write($"'{inputChoice}': is not valid, please try again: ");
                inputChoice = Console.ReadLine();
            }

            if (choice == 1)
            {
                string currentPrompt = prompt.GetRandomPrompt();
                Console.WriteLine(currentPrompt);
                string inputEntry = Console.ReadLine();

                while (inputEntry == null)
                {
                    Console.WriteLine("Empty entries not allowed. Try again:");
                    Console.Write("Your entry: ");
                    inputEntry = Console.ReadLine();
                }

                newEntry._date = DateTime.Now.ToString("yyyy/MM/dd");
                newEntry._prompt = currentPrompt;
                newEntry._entryText = inputEntry;

                myJournal.AddEntry(newEntry);

                newEntry = new Entry();
            }
            else if (choice == 2)
            {
                if (myJournal._entries != null)
                {
                    myJournal.DisplayAll();
                }
                else
                {
                    Console.WriteLine("Sorry, the current journal is empty.");
                }
            }
            else if (choice == 3)
            {
                if (myJournal._entries != null)
                {
                    Console.WriteLine("What is the filename? ");
                    string FileName = Console.ReadLine();

                    while (!string.IsNullOrWhiteSpace(FileName))
                    {
                        Console.Write("Please enter a valid file name: ");
                        FileName = Console.ReadLine();
                    }

                    myJournal.SaveToFile(FileName);
                }
                else
                {
                    Console.WriteLine("There is nothing to save.");
                }
            }
            else if (choice == 4)
            {
                Console.WriteLine("What is the filename? ");
                string FileName = Console.ReadLine();

                while (!string.IsNullOrWhiteSpace(FileName))
                {
                    Console.Write("Please enter a valid file name: ");
                    FileName = Console.ReadLine();
                }

                myJournal.LoadFromFile(FileName);

            }
            else if (choice == 5)
            {
                break;
            }
        }
    }
}