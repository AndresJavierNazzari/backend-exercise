// See https://aka.ms/new-console-template for more information
using GenericDataStorage;

Console.WriteLine("Hello, World!");

DataStorage<Person> personStorage = new();
Person person = new("Andres", 36);
Person person2 = new("Andres2", 36);

personStorage.Add(person);
personStorage.Add(person2);
personStorage.DisplayItems();
personStorage.Remove(person);
personStorage.DisplayItems();

DataStorage<Car> carStorage = new();
Car car = new("Ferrari", "365");
Car car2 = new("Tesla", "R2D2");

carStorage.Add(car);
carStorage.Add(car2);
carStorage.DisplayItems();
carStorage.Remove(car);
carStorage.DisplayItems();
