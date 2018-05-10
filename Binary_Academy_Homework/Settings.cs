using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Academy_Homework
{
    static class Settings
    {
        static public int Timeout { get; private set; }

        static public readonly Dictionary<CarType, double> Dictionary;

        static public int ParkingSpace { get; private set; }

        static public double Fine { get; private set; }

        static Settings()
        {
            Timeout = 3000;
            Dictionary = new Dictionary<CarType, double>()
            {
                [CarType.Bus] = 2,
                [CarType.Motorcycle] = 1,
                [CarType.Passenger] = 3,
                [CarType.Truck] = 4
            };
            ParkingSpace = 300;
            Fine = 1.5;
        }
    }
}
