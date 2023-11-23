namespace InputCommands;

internal class Program
{
    static List<string> textCommands = new List<string>();
    static List<int> numericCommands = new List<int>();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Input Commands Manager!");

        while (true)
        {
            PrintMenu();
            char choice = GetChoice();

            switch (choice)
            {
                case '1':
                    Console.Clear();
                    InputCommands();
                    break;
                case '2':
                    Console.Clear();
                    ShowCategories();
                    break;
                case '3':
                    Console.Clear();
                    Console.WriteLine("Exiting the Input Commands Manager...");
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid Choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }


    static void PrintMenu()
    {
        Console.WriteLine("Please choose an option: ");
        Console.WriteLine("1. Input Command");
        Console.WriteLine("2. Show Categories");
        Console.WriteLine("3. Exit");
    }

    static char GetChoice()
    {
        char choice;
        while (!char.TryParse(Console.ReadKey().KeyChar.ToString(), out choice) || (choice < '1' || choice > '3'))
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
            Console.Write("Enter your choice (1-3): ");
        }

        return choice;
    }

    static void InputCommands()
    {
        Console.Write("Enter commands (text or numbers): ");
        string? userInput = Console.ReadLine();

        while (string.IsNullOrEmpty(userInput))
        {
            Console.WriteLine("Invalid input. Please enter a non-empty value.");
            userInput = Console.ReadLine();
        }

        CategorizeInput(userInput.Trim());
    }

    static void CategorizeInput(string userInput)
    {
        if (int.TryParse(userInput, out int numericValue))
        {
            numericCommands.Add(numericValue);
        }
        else
        {
            textCommands.Add(userInput);
        }
    }

    static void ShowCategories()
    {
        Console.WriteLine("\nText Commands:");
        foreach (var textCommand in textCommands)
        {
            Console.WriteLine($"- {textCommand}");
        }

        Console.WriteLine("\nNumeric Commands:");
        foreach (var numericCommand in numericCommands)
        {
            Console.WriteLine($"- {numericCommand}");
        }
    }
}
