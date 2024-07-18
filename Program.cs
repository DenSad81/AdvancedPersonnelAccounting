using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        const char CommandAddFile = '1';
        const char CommandPrintAllFiles = '2';
        const char CommandDeleteFile = '3';
        const char CommandSerchInFiles = '4';
        const char CommandExit = '5';

        Dictionary<string, List<string>> files = new Dictionary<string, List<string>>()
            {
                {"рабочий",new List <string>{ "Дмитрий Петров", "Анатолий Сидоров"} },
                {"инженер",new List <string>{ "Евгений Смирнов", "Алексей Андреев"} },
                {"босс",new List <string>{ "Павел Аренок"} },
            };
        char choiceOfMenu;
        bool isRun = true;

        while (isRun)
        {
            Console.WriteLine($"Menu: {CommandAddFile}-add file;");
            Console.WriteLine($"      {CommandPrintAllFiles}-print all files;");
            Console.WriteLine($"      {CommandDeleteFile}-delete file;");
            Console.WriteLine($"      {CommandSerchInFiles}-serch in file;");
            Console.WriteLine($"      {CommandExit}-exit;");
            Console.Write("Your shois: ");
            choiceOfMenu = Convert.ToChar(Console.ReadLine());

            switch (choiceOfMenu)
            {
                case CommandAddFile:
                    AddUserFile(files);
                    break;

                case CommandPrintAllFiles:
                    PrintAllFiles(files);
                    break;

                case CommandDeleteFile:
                    DeleteEmpluae(files);
                    break;

                case CommandSerchInFiles:
                    SearchInUserFile(files);
                    break;

                case CommandExit:
                    isRun = false;
                    break;
            }
        }
    }

    static void AddUserFile(Dictionary<string, List<string>> files)
    {
        Console.Write("Inpout last name of man: ");
        string lastName = Console.ReadLine();

        Console.Write("Inpout vacancy of man: ");
        string vacancy = Console.ReadLine();

        if (files.ContainsKey(vacancy))
            files[vacancy].Add(lastName);
        else
            files.Add(vacancy, new List<string> { lastName });
    }

    static void PrintAllFiles(Dictionary<string, List<string>> files)
    {
        foreach (var file in files)
        {
            Console.Write(file.Key + " ");

            foreach (var item in file.Value)
                Console.Write("  " + item);

            Console.WriteLine();
        }
    }

    static void DeleteEmpluae(Dictionary<string, List<string>> files)
    {
        Console.Write("Input first and last name of man: ");
        string firstNamelastName = Console.ReadLine();
        Console.Write("Input vacancy of man: ");
        string vacancy = Console.ReadLine();
        Console.Write("Input id of man: ");
        int idMan = GetIntFromConsole();

        if (files.ContainsKey(vacancy))
            files[vacancy].RemoveAt(idMan);

        if (files[vacancy].Count == 0)
            files.Remove(vacancy);
    }

    static void SearchInUserFile(Dictionary<string, List<string>> files)
    {
        bool isManPresent = false;
        Console.Write("Input last name of man: ");
        string lastName = Console.ReadLine();

        foreach (var file in files)
        {
            foreach (var item in file.Value)
            {
                if (item == lastName)
                {
                    Console.WriteLine(file.Key + " - " + item);
                    isManPresent = true;
                }
            }
        }

        if (isManPresent == false)
            Console.WriteLine("No man is present");
    }

    static int GetIntFromConsole()
    {
        int digitToOut = 0;
        bool stopCikle = true;

        while (stopCikle)
        {
            Console.Write("Введите число: ");
            string digitFromConsole = Console.ReadLine();
            bool isRun = int.TryParse(digitFromConsole, out digitToOut);
            stopCikle = !isRun;
        }

        return digitToOut;
    }
}