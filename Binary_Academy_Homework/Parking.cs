using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Binary_Academy_Homework
{
    class Parking
    {
        private static readonly Lazy<Parking> lazy = new Lazy<Parking>(() => new Parking());

        public static Parking Instance { get { return lazy.Value; } }

        public Timer Timer { get => timer; set => timer = value; }

        static List<Car> listCars;

        static List<Transaction> listTransactions;

        static double Balance;

        private Parking()
        {
            //Parking - данный класс при инициализации использует настройки описанные в классе Settings:
            listCars = new List<Car>();
            listTransactions = new List<Transaction>();
        }

        public void AddCar(Car car)
        {
            if (car != null)
                listCars.Add(car);
        }

        public void RemoveCar(Car car)
        {
            if (car != null && car.Balance >= 0)
                listCars.Remove(car);
            if(car.Balance < 0)
                Console.WriteLine($"Your balance {car.Balance}, please top up balance and try again");
        }

        private Timer timer = new Timer(new TimerCallback(new Parking().CashBack), null, 0, Settings.Timeout);

        private void CashBack(object obj)
        {
            foreach (var item in listCars)
            {
                if (item.Balance < Settings.Dictionary[item.CarType])
                    item.Balance -= Settings.Dictionary[item.CarType] * Settings.Fine;
                else
                    item.Balance -= Settings.Dictionary[item.CarType];
            }
        }
    }
}
