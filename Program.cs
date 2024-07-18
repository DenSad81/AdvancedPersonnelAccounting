using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        const int CommandAddFile = 1;
        const int CommandPrintAllFiles = 2;
        const int CommandDeleteFile = 3;
        const int CommandSerchInFiles = 4;
        const int CommandExit = 5;

        Dictionary<string, List<string>> dossiers = new Dictionary<string, List<string>>()
            {
                {"рабочий",new List <string>{ "Дмитрий Петров", "Анатолий Сидоров"} },
                {"инженер",new List <string>{ "Евгений Смирнов", "Алексей Андреев"} },
                {"босс",new List <string>{ "Павел Аренок"} },
            };
        int userInput;
        bool isRun = true;

        while (isRun)
        {
            Console.WriteLine($"Menu: {CommandAddFile}-add file;");
            Console.WriteLine($"      {CommandPrintAllFiles}-print all files;");
            Console.WriteLine($"      {CommandDeleteFile}-delete file;");
            Console.WriteLine($"      {CommandSerchInFiles}-serch in file;");
            Console.WriteLine($"      {CommandExit}-exit;");
            Console.Write("Your shois: ");
            userInput = ReadInt();

            switch (userInput)
            {
                case CommandAddFile:
                    AddDossier(dossiers);
                    break;

                case CommandPrintAllFiles:
                    PrintAllDossier(dossiers);
                    break;

                case CommandDeleteFile:
                    DeleteEmployee(dossiers);
                    break;

                case CommandSerchInFiles:
                    SearchInUserDossier(dossiers);
                    break;

                case CommandExit:
                    isRun = false;
                    break;
            }
        }
    }

    static void AddDossier(Dictionary<string, List<string>> dossiers)
    {
        Console.Write("Input full name of man: ");
        string fullName = Console.ReadLine();

        Console.Write("Inpout vacancy of man: ");
        string vacancy = Console.ReadLine();

        if (dossiers.ContainsKey(vacancy))
            dossiers[vacancy].Add(fullName);
        else
            dossiers.Add(vacancy, new List<string> { fullName });
    }

    static void PrintAllDossier(Dictionary<string, List<string>> dossiers)
    {
        foreach (var dossie in dossiers)
        {
            Console.Write(dossie.Key + " ");

            foreach (var name in dossie.Value)
                Console.Write("  " + name);

            Console.WriteLine();
        }
    }

    static void DeleteEmployee(Dictionary<string, List<string>> dossiers)
    {
        Console.Write("Input vacancy of man: ");
        string vacancy = Console.ReadLine();
        Console.Write("Input id of man: ");
        int idMan = ReadInt();

        if (idMan < 0 || dossiers[vacancy].Count <= idMan)
            return;

        if (dossiers.ContainsKey(vacancy))
            dossiers[vacancy].RemoveAt(idMan);

        if (dossiers[vacancy].Count == 0)
            dossiers.Remove(vacancy);
    }

    static void SearchInUserDossier(Dictionary<string, List<string>> dossiers)
    {
        bool isManPresent = false;
        Console.Write("Input full name of man: ");
        string fullName = Console.ReadLine();

        foreach (var dossie in dossiers)
        {
            foreach (var name in dossie.Value)
            {
                if (name == fullName)
                {
                    Console.WriteLine(dossie.Key + " - " + name);
                    isManPresent = true;
                }
            }
        }

        if (isManPresent == false)
            Console.WriteLine("No man is present");
    }

    static int ReadInt()
    {
        int number;

        while (int.TryParse(Console.ReadLine(), out number) == false)
        { }

        return number;
    }
}