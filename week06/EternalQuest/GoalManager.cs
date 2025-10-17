using System.Security.Cryptography.X509Certificates;

public class GoalManager
{
    private List<Goal> Goals = new List<Goal>();
    private int _score;

    public int Score {
        get { return _score; }
        set { _score = value; } 
        }

    public GoalManager()
    {
        _score = 0;
    }

    public void Start()
    {

        while (true)
        {
            DisplayPlayerInfo();

            Console.Write($"Menu Options:{Environment.NewLine}  1. Create new goal.{Environment.NewLine}  2. List goals{Environment.NewLine}  3. Save goals{Environment.NewLine}  4. Load goals{Environment.NewLine}  5. Record event{Environment.NewLine}  6. Quit{Environment.NewLine}Select a choice from the menu:  ");
            string inputChoice = Console.ReadLine();

            int choice = 0;
            if (!int.TryParse(inputChoice, out choice) || choice < 1 || choice > 6)
            {
                Console.WriteLine("Invalid Entry. Please try again.");
                continue;
            }

            if (choice == 1)
            {
                CreateGoal();
                continue;
            }else if (choice == 2){
                ListGoalNames();
                continue;
            } else if(choice == 3)
            {
                Console.Write("Please type in the file name: ");
                string fileName = Console.ReadLine();

                SaveGoals(fileName);

                continue;
            } else if (choice == 4)
            {
                Console.Write("Please type in the file name: ");
                string fileName = Console.ReadLine();

                LoadGoals(fileName);
            } else if (choice == 5)
            {

                RecordEvent();
                continue;
            } else
            {
                break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {Score} points.");
    }

    public void LoadGoals(string path)
    {

        string line = "";
        int count = 0;
        SimpleGoal simpleGoal = null;
        EternalGoal eternalGoal = null;
        CheckListGoal checkList = null;

        try {
            using (StreamReader sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (count == 0)
                    {
                        if (!int.TryParse(line, out int scoreFromFile))
                        {
                            Console.WriteLine("Error: invalid score format in file. Try Again.");
                            return;
                        }
                        Score = scoreFromFile;
                    }
                    else
                    {
                        string[] data = line.Split(':');
                        string typeOfGoal = data[0];
                        string[] goalData = data[1].Split(',');

                        if (typeOfGoal == "SimpleGoal")
                        {
                            simpleGoal = new SimpleGoal(goalData[0], goalData[1], goalData[2], bool.Parse(goalData[3]));
                            Goals.Add(simpleGoal);

                        }
                        else if (typeOfGoal == "EternalGoal")
                        {
                            eternalGoal = new EternalGoal(goalData[0], goalData[1], goalData[2]);
                            Goals.Add(eternalGoal);
                        }
                        else
                        {
                            checkList = new CheckListGoal(goalData[0], goalData[1], goalData[2], int.Parse(goalData[3]), int.Parse(goalData[4]), int.Parse(goalData[5]));
                            Goals.Add(checkList);
                        }
                    }

                    count++;
                }
            }
        } catch (FileNotFoundException)
        {
            Console.WriteLine($"File Not Found. Try Again.{Environment.NewLine}");
        }

    }

    public void SaveGoals(string path)
    {

        using (StreamWriter sw = new StreamWriter(path))
        {
            sw.WriteLine(Score);

            foreach (Goal goal in Goals)
            {
                sw.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void CreateGoal()
    {

        int choice = 0;

        Console.Write($"{Environment.NewLine}The type of goals are:{Environment.NewLine}1. Simple Goal{Environment.NewLine}2. Eternal Goal{Environment.NewLine}3. Checklist Goal{Environment.NewLine}What type of goal would you like to create? ");
        string inputGoalTO = Console.ReadLine();

        while (!int.TryParse(inputGoalTO, out choice) || choice < 1 || choice > 3)
        {
            Console.WriteLine($"Invalid Entry. Try Again.{Environment.NewLine}");
            inputGoalTO = Console.ReadLine();
        }

        if (choice == 1)
        {
            Console.Write($"{Environment.NewLine}What is the name of your goal? ");
            string inputName = Console.ReadLine();

            Console.Write($"What is a short description of it? ");
            string inputDescription = Console.ReadLine();

            Console.Write($"What is the amount of points associated with this goal? ");
            string inputPoints = Console.ReadLine();


            SimpleGoal simpleGoal = new SimpleGoal(inputName, inputDescription, inputPoints);
            Goals.Add(simpleGoal);
        }
        else if (choice == 2)
        {
            Console.Write($"{Environment.NewLine}What is the name of your goal? ");
            string inputName = Console.ReadLine();

            Console.Write($"What is a short description of it? ");
            string inputDescription = Console.ReadLine();

            Console.Write($"What is the amount of points associated with this goal? ");
            string inputPoints = Console.ReadLine();

            EternalGoal eternalGoal = new EternalGoal(inputName, inputDescription, inputPoints);
            Goals.Add(eternalGoal);
        }
        else
        {
            Console.Write($"{Environment.NewLine}What is the name of your goal? ");
            string inputName = Console.ReadLine();

            Console.Write($"What is a short description of it? ");
            string inputDescription = Console.ReadLine();

            Console.Write($"What is the amount of points associated with this goal? ");
            string inputPoints = Console.ReadLine();

            Console.Write($"How many times does this goal need to be completed for a bonus? ");
            string inputNTimes = Console.ReadLine();

            int _NTimes = 0;
            while (!int.TryParse(inputNTimes, out _NTimes))
            {
                Console.WriteLine($"Invalid Entry. Try Again.{Environment.NewLine}");
                inputNTimes = Console.ReadLine();
            }

            Console.Write($"What is the bonus for accomplishing this goal?  ");
            string inputBonus = Console.ReadLine();

            int _bonus = 0;
            while (!int.TryParse(inputBonus, out _bonus))
            {
                Console.Write($"Invalid Entry. Try Again: {Environment.NewLine}");
                inputBonus = Console.ReadLine();
            }

            CheckListGoal checkList = new CheckListGoal(inputName, inputDescription, inputPoints, _bonus, _NTimes, 0);
            Goals.Add(checkList);
        }
    }

    public void ListGoalNames()
    {
        int index = 1;
        foreach (Goal goal in Goals)
        {
            Console.WriteLine($"{index}. {goal.Name}");
            index++;
        }
    }

    public void ListGoalDetails()
    {
        for (int i = 0; i < Goals.Count(); i++)
        {
            Console.WriteLine($"{i + 1}. {Goals[i].GetDetailsString()}");
        }
    }
    
    public void RecordEvent()
    {
        if (Goals == null || Goals.Count == 0)
        {
            Console.WriteLine($"There are no goals yet.{Environment.NewLine}");
            return;
        }

        // Mostrar nombres para elegir
        Console.WriteLine($"{Environment.NewLine}The goals are:");
        ListGoalDetails();

        // Leer índice válido (solo números dentro del rango)
        int index;
        while (true)
        {
            Console.Write($"{Environment.NewLine}Which goal did you accomplish? ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out index))
            {
                Console.WriteLine("Invalid Entry. Please enter a number.");
                continue;
            }

            index -= 1; // el usuario ve 1..N, la lista es 0..N-1

            if (index < 0 || index >= Goals.Count)
            {
                Console.WriteLine("That goal number doesn't exist. Try Again.");
                continue;
            }

            break;
        }

        Goal goal = Goals[index];
        int earned = 0;

        // --- SimpleGoal ---
        if (goal is SimpleGoal sg)
        {
            bool wasComplete = sg.IsComplete();  
            sg.RecordEvent();                   

            if (!wasComplete && sg.IsComplete())
            {
                earned = int.Parse(sg.Points);
            }
        }
        // --- EternalGoal ---
        else if (goal is EternalGoal eg)
        {
            eg.RecordEvent();    
            earned = int.Parse(eg.Points);
        }
        // --- CheckListGoal ---
        else if (goal is CheckListGoal cg)
        {
            int before = cg.AmountCompleted;
            cg.RecordEvent();                
            int after = cg.AmountCompleted;

            if (after > before)
            {

                if (cg.IsComplete()){
                    earned = int.Parse(cg.Points) + cg.Bonus;
                }
                else
                {
                    earned = int.Parse(cg.Points);
                }
            }
        }

        Score = Score + earned;
        
    }
}