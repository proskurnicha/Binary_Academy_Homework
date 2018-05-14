using ClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebParking.Services
{
    public class Processing
    {
        Parking parking;

        public Processing()
        {
            parking = new Parking();
            parking.AddCar(new Car { Identifier = "A", Balance = 300, CarType = CarType.Bus });
        }

        public List<Car> GetCars()
        {
            return Parking.listCars;
        }

        public void AddCar(Car car)
        {
            parking.AddCar(car);
        }

        public List<Transaction> GetTransaction()
        {
            return parking.GetTransactions();
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
