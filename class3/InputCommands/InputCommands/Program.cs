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
                    break;
                case '2':
                    Console.Clear();
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
        Console.Write("Enter your choice (1-3): ");
        return Console.ReadKey().KeyChar;
    }
}
