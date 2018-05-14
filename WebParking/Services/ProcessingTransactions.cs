using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;

namespace WebParking.Services
{
    public class ProcessingTransactions
    {
        Parking parking;

        public ProcessingTransactions()
        {
            parking = new Parking();
        }

        public List<Car> GetCars()
        {
            return Parking.listCars;
        }

        public List<Transaction> GetTransaction()
        {
            return parking.GetTransactions();
        }
    }
}
