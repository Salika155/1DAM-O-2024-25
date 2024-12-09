namespace w
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new();
            Wheel wheel = new();

            car.AddWheel(wheel);

            Car car1 = new();
            Car car2 = new();
            Wheel w = new();
            car1.AddWheel(w);
            car2.AddWheel(w);

            
        }
    }
}
