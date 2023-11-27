namespace VehicleManagement
{
    internal abstract class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }

        public abstract void Start();
        public abstract void Stop();


    }
}
