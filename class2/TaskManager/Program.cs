namespace TaskManager;

internal class Program
{
    static List<Task> tasks = new List<Task>();
    static int taskIdCounter = 1;

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Task Manager!");

        while (true) {
            printMenu();
            char choice = getChoice();

            switch (choice) {
                case '1':
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    Console.WriteLine("Exiting the Task Manager...");
                    return;
                default:
                    Console.WriteLine("Invalid Choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }       
    }


    static void printMenu()
    {
        Console.WriteLine("Please choose an option: ");
        Console.WriteLine("1. Add a task");
        Console.WriteLine("2. View tasks");
        Console.WriteLine("3. mark Task as Completed");
        Console.WriteLine("4. Exit");
        Console.WriteLine("Enter your choice (1-4): ");
    }

    static char getChoice()
    {
        Console.Write("Enter your choice (1-4): ");
        return Console.ReadKey().KeyChar;
    }

}



class Task {
    public int id { get; set; }
    public string description { get; set; }
    public bool isCompleted { get; set; }
}