# Class 19

- Create a class called "EventManager" that manages a collection of events. 
- The class should have methods to add and remove events, as well as a method to invoque all the registered events.
- Use Func<string, bool> delegates to represent the events.
- Write code to add mltiple events of different types and invoke them, the order should be the following, the last event is the first being executed.
- Every event will be represented as Func<string, bool> returns a bool that represent if the operation was successful and a string that holds the information of that operation (for complex operations consider using this string to represent objects using JSON)
- The main goal is to use the EventManager as playboo, to reproduce the events captured in its collection.

Utilizar tipo de datos stack para almacenar los eventos

Definicion de eventos, por ejemplo: partido de futbol, carrera de formula 1, partido de tennis, etc