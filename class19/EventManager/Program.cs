namespace EventManager;
internal class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello, World!");

        EventManager eventManager = new EventManager();

        // Add events in the desired order
        eventManager.AddEvent(FootballMatch);
        eventManager.AddEvent(Formula1Race);
        eventManager.AddEvent(TennisMatch);

        // Invoke events in the reverse order
        eventManager.InvokeEvents();


    }

    static bool FootballMatch(string info) {
        Console.WriteLine($"Football match: {info}");
        return true;
    }

    static bool Formula1Race(string info) {
        Console.WriteLine($"Formula 1 Race: {info}");
        // Perform Formula 1 race operation
        return true;
    }

    static bool TennisMatch(string info) {
        Console.WriteLine($"Tennis Match: {info}");
        // Perform tennis match operation
        return true;
    }

}

