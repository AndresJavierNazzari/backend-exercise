// See https://aka.ms/new-console-template for more information
using GenericDataStorage;

Console.WriteLine("Hello, World!");

DataStorage<Person> personStorage = new DataStorage<Person>();
Person person2 = new Person("Andres2", 36);

personStorage.Add(new Person("Andres", 36));
personStorage.Add(person2);


Console.WriteLine(DataStorage<Person>.TotalItems);

