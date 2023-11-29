namespace GenericDataStorage
{
    internal class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }

        public Car(string brand, string model)
        {
            this.Brand = brand;
            this.Model = model;
        }
        public Car()
        {

        }
        public void Start()
        {
            Console.WriteLine($"The {nameof(Car)} {Brand} {Model} is starting...");
        }

        public void Stop()
        {
            Console.WriteLine($"The {nameof(Car)} {Brand} {Model} is stopping");
        }
    }
}
