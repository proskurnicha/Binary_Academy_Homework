using System;
using System.Collections.Generic;
using System.Threading;

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

        public static int CountFreeParkingSpace { get; private set; }

        private Parking()
        {
            //Parking - данный класс при инициализации использует настройки описанные в классе Settings:
            listCars = new List<Car>();
            listTransactions = new List<Transaction>();
            CountFreeParkingSpace = Settings.ParkingSpace;
        }

        public void AddCar(Car car)
        {
            if (car != null && CountFreeParkingSpace > 0)
            {
                CountFreeParkingSpace--;
                listCars.Add(car);
            }
            else
            {
                Console.WriteLine("Sorry, parking don`t have a free parking place");
            }
        }

        public void RemoveCar(Car car)
        {
            if (car != null && car.Balance >= 0)
                listCars.Remove(car);
            if (car.Balance < 0)
                Console.WriteLine($"Your balance {car.Balance}, please top up balance and try again");
        }

        private Timer timer = new Timer(new TimerCallback(new Parking().CashBack), null, 0, Settings.Timeout);

        private void CashBack(object obj)
        {
            double writtenOfMoney;
            foreach (var car in listCars)
            {

                if (car.Balance < Settings.Dictionary[car.CarType])
                {
                    writtenOfMoney = Settings.Dictionary[car.CarType] * Settings.Fine;
                }
                else
                {
                    writtenOfMoney = Settings.Dictionary[car.CarType];
                }
                car.Balance -= writtenOfMoney;
                Balance += writtenOfMoney;
                Transaction transaction = new Transaction() { DateTransaction = DateTime.Now, IdentifierCar = car.Identifier, WrittenOffFunds = writtenOfMoney };
                listTransactions.Add(transaction);
            }
        }
    }
}
