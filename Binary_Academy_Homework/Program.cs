using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Academy_Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Parking parking = new Parking();
            parking.AddCar(new Car() { Balance = 5, CarType = CarType.Motorcycle, Identifier = "AA23" });
            parking.AddCar(new Car() { Balance = 4, CarType = CarType.Passenger, Identifier = "AA24" });
            parking.AddCar(new Car() { Balance = 3, CarType = CarType.Truck, Identifier = "AA25" });
            Car car = new Car()
            {
                Balance = 8,
                CarType = CarType.Bus,
                Identifier = "AA25"
            };
            parking.AddCar(car);
            parking.RemoveCar(car);
            
            Console.ReadLine();
        }
    }
}

