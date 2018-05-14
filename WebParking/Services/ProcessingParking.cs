using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebParking.Services
{
    public class ProcessingParking
    {
        Parking parking;

        public ProcessingParking()
        {
            parking = new Parking();
        }

        public int GetCountFreePlace()
        {
           return parking.CountFreeParkingSpace;
        }

        public int GetCountOqPlace()
        {
            return Settings.ParkingSpace - GetCountFreePlace();
        }

        public double GetBalance()
        {
            return Parking.Balance;
        }
    }
}
