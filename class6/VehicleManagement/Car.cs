using System;

namespace VehicleManagement
{
    internal class Car : Vehicle
    {
        public override void Start()
        {
            Console.WriteLine($"The {nameof(Car)} {Brand} {Model} is starting...");
        }

        public override void Stop()
        {
            Console.WriteLine($"The {nameof(Car)} {Brand} {Model} is stopping");
        }
    }
}
