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

        public void AddCar(Car car)
        {
            Program.parking.AddCar(car);
        }

        public List<Transaction> GetTransaction()
        {
            return Program.parking.GetTransactions();
        }

        public List<Transaction> GetTransactionLastMinute()
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
