using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Binary_Academy_Homework
{
    class Parking
    {
        private static readonly Lazy<Parking> lazy = new Lazy<Parking>(() => new Parking());

        public static Parking Instance { get { return lazy.Value; } }

        static List<Car> listCars;

        static List<Transaction> listTransactions;

        static double Balance;

        public static int CountFreeParkingSpace { get; private set; }

        public Parking()
        {
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

        private Timer timer = new Timer(new TimerCallback(new Parking().CashBack), null, 0, 60000);

        private Timer timerWriteTransaction = new Timer(new TimerCallback(new Parking().WriteToFileTransactions), null, 0, 60000);

        private void WriteToFileTransactions(object obj)
        {
            listTransactions.RemoveAll(TimesMoreThanOneMinute);
            FileStream file = File.Open("Transaction.log", FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter(file);
            streamWriter.WriteLine(listTransactions[0].DateTransaction.ToShortDateString());
            foreach (var item in listTransactions)
            {
                streamWriter.WriteLineAsync(item.ToString());
            }
            streamWriter.Close();
            file.Close();
        }

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
        private static bool TimesMoreThanOneMinute(Transaction transaction)
        {
            TimeSpan span = new TimeSpan();
            span = DateTime.Now.Subtract(transaction.DateTransaction);
            return span.TotalSeconds > 60;
        }

        public void GetTransactions()
        {
            FileStream file = File.Open("Transaction.log", FileMode.OpenOrCreate);
            StreamReader streamReader = new StreamReader(file);
            string input;
            Console.WriteLine($"Date: {streamReader.ReadLine()}");
            while ((input = streamReader.ReadLine()) != null)
            {
                Console.WriteLine(input);
            }
        }
    }
}
