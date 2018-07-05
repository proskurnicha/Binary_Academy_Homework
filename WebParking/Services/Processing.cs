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
        public List<Car> GetCars()
        {
            return Parking.listCars;
        }

        public List<Car> GetCarsById(string id)
        {
            return Parking.listCars.Where(x => x.Identifier == id).ToList();
        }

        public void AddCar(Car car)
        {
            Program.parking.AddCar(car);
        }

        public bool RemoveCarById(string id)
        {
            Car car = GetCars().First(x => x.Identifier == id);
            if (car != null)
            {
                GetCars().Remove(car);
                return true;
            }
            return false;
        }

        public List<Transaction> GetTransactions()
        {
            return Program.parking.GetTransactions();
        }

        public List<Transaction> GetTransactionsLastMinute()
        {
            return Program.parking.GetTransactionsLastMinute();
        }

        public int GetCountFreePlace()
        {
            return Program.parking.CountFreeParkingSpace;
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
