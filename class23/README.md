# Quick Excercise
Using the gRPC Client Project from C# fundamentals repository, currently we are using the gRPC server to send requests, now alongside sending the request i need to save the request and the response with the time they were sent in a file, you can use a .txt file.

Add a stopwatch timer and measure the time it takes to send the request and save it and the response in a file. The timer should print the result in console and should also log that information in the file.
Every new request made a new instace of the timer is created. More informacion on the stopwatch class is here: https://code-maze.com/csharp-stopwatch/

It is important to use async operation that way we dont block the thread in wich the stopwatch is running