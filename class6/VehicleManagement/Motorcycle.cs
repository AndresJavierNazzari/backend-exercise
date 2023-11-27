namespace VehicleManagement
{
    internal class Motorcycle : Vehicle
    {
        public override void Start()
        {
            Console.WriteLine($"The {nameof(Motorcycle)} {Brand} {Model} is starting...");
        }

        public override void Stop()
        {
            Console.WriteLine($"The {nameof(Motorcycle)} {Brand} {Model} is stopping...");
        }
    }
}
