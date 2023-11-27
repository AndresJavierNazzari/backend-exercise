// See https://aka.ms/new-console-template for more information
using VehicleManagement;

Console.WriteLine("Welcome to Vehicle Management App!");

Car car1 = new Car();
car1.Brand = "Tesla";
car1.Model = "x38";

Car car2 = new Car { Brand = "Ferrari", Model = "486" };

Motorcycle moto1 = new Motorcycle();
moto1.Model = "Harley";
moto1.Brand = "davidson28";


Console.WriteLine($"My {car1.Brand} {car1.Model}");
car1.Start();
car1.Stop();

Console.WriteLine($"My {car2.Brand} {car2.Model}");
car2.Start();
car2.Stop();

Console.WriteLine($"My {moto1.Brand} {moto1.Model}");
moto1.Start();
moto1.Stop();
