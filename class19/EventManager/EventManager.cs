using System;

namespace EventManager;

internal class EventManager {
    private Stack<Func<string, bool>> eventStack;
    private int eventCounter;

    public EventManager() {
        eventStack = new Stack<Func<string, bool>>();
        eventCounter = 1;
    }
    public void AddEvent(Func<string, bool> eventHandler) {
        eventStack.Push(eventHandler);
    }

    public void RemoveEvent(Func<string, bool> eventHandler) {
        if(eventStack.Count > 0) {
            eventStack.Pop();
        }
    }

    public void InvokeEvents() {

        Console.WriteLine($"for each");
        foreach(var eventHandler in eventStack) {
            string eventInfo = $"Event {eventCounter} - {eventHandler.Method.Name}";
            Console.WriteLine($"Event Result: {eventHandler.Invoke(eventInfo)}");
            eventCounter++;
        }
    }

}

