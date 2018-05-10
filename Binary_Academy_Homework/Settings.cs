using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Academy_Homework
{
    enum TypeAuto
    {
        Truck,
        PassengerCar,
        Motorcycle,
        Bus
    }
    static class Settings
    {
        static public int Timeout { get; private set; }

        static readonly Dictionary<TypeAuto, double> Dictionary;

        static public int ParkingSpace { get; private set; }

        static public double Fine { get; private set; }

        static Settings()
        {
            Timeout = 3;
            Dictionary = new Dictionary<TypeAuto, double>()
            {
                [TypeAuto.Bus] = 2,
                [TypeAuto.Motorcycle] = 1,
                [TypeAuto.PassengerCar] = 3,
                [TypeAuto.Truck] = 4
            };
            ParkingSpace = 300;
            Fine = 0.5;
        }
    }
}
