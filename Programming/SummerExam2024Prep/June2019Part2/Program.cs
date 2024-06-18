using June2019;
using System;
namespace June2019Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car(100, 10));
            cars.Add(new Car(100, 3));
            cars.Add(new HybridCar(100, 5, 20));
            cars.Add(new HybridCar(80, 2, 40));

            Table.InitTable();
            foreach (Car c in cars)
            {
                Console.WriteLine(c.ToString());
            }
        }
    }
}
