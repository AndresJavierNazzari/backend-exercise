namespace TaskManager;

internal class Program
{
    static List<Task> tasks = new List<Task>();
    static int taskIdCounter = 1;

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Task Manager!");

        while (true) {
            PrintMenu();
            char choice = GetChoice();

            switch (choice) {
                case '1':
                    Console.Clear();
                    AddTask();
                    break;
                case '2':
                    Console.Clear();
                    ViewTasks();
                    break;
                case '3':
                    Console.Clear();
                    ChangeTaskStatus();
                    break;
                case '4':
                    Console.Clear();
                    Console.WriteLine("Exiting the Task Manager...");
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
        Console.WriteLine("1. Add a task");
        Console.WriteLine("2. View tasks");
        Console.WriteLine("3. Change Task Status");
        Console.WriteLine("4. Exit");
    }

    static char GetChoice()
    {
        Console.Write("Enter your choice (1-4): ");
        return Console.ReadKey().KeyChar;
    }

    static void AddTask()
    {
        Console.Write("Enter the Task Description: ");
        string? description = Console.ReadLine();

        Task newTask = new Task
        {
            Id = taskIdCounter++,
            Description = description,
            IsCompleted = false,
        };

        tasks.Add(newTask);
        Console.WriteLine("Task added successfully!");
    }

    static void ViewTasks()
    {
        if (tasks.Count == 0)
        {
            Console.Write("Task list empty...");
            return;
        }
        else
        {
            Console.WriteLine("Tasks: ");
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.Id}. {task.Description} - Completed: {task.IsCompleted}");
            }
        }
    }

    static void ChangeTaskStatus()
    {
        if (tasks.Count == 0 ) 
        {
            Console.WriteLine("No tasks to mark as completed/incomplete. Task list empty...");
            return;
        }

        Console.WriteLine("Select the task to to change status (completed/incomplete): ");

        foreach (var task in tasks)
        {
            Console.WriteLine($"{task.Id}. {task.Description} - Completed: {task.IsCompleted}");
        }
        Console.WriteLine("Enter the number of the task to change status: ");

        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber >= 1 && taskNumber<= tasks.Count)
        {
            tasks[taskNumber-1].IsCompleted = !tasks[taskNumber-1].IsCompleted;
            Console.WriteLine("Task status updated!");
        } else
        {
            Console.WriteLine("Invalid task number. Please try again.");
        }
    }
}

class Task {
    public int Id { get; set; }
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
}
