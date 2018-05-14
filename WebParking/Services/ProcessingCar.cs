using ClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebParking.Services
{
    public class ProcessingCar
    {
        Parking parking;

        public ProcessingCar()
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

    }
}
