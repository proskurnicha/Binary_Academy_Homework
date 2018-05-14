using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ClassLibrary
{
    public class Parking
    {
        private static readonly Lazy<Parking> lazy = new Lazy<Parking>(() => new Parking());

        public static Parking Instance { get { return lazy.Value; } }

        public static List<Car> listCars;

        static List<Transaction> listTransactions;

        public static double Balance { get; private set; }

        public static double BalanceLastMinute { get; private set; }

        public int CountFreeParkingSpace { get; private set; }

        public Parking()
        {
            listCars = new List<Car>();
            listTransactions = new List<Transaction>();
            CountFreeParkingSpace = Settings.ParkingSpace;
        }

        public bool AddCar(Car car)
        {
            if (car != null && CountFreeParkingSpace > 0)
            {
                CountFreeParkingSpace--;
                listCars.Add(car);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveCar(string identifier)
        {
            Car car = null;
            foreach (var item in listCars)
            {
                if (identifier == item.Identifier)
                    car = item;
            }

            if (car != null && car.Balance >= 0)
            {
                listCars.Remove(car);
                CountFreeParkingSpace++;
                return true;
            }

            if (car != null && car.Balance < 0)
                Console.WriteLine($"Your balance {car.Balance}, please top up balance and try again");
            return false;
        }

        private Timer timer = new Timer(WrittenOfMoney, null, 1000, Settings.Timeout);

        private Timer timerWriteTransaction = new Timer(WriteToFileTransactions, null, 1000, 60000);

        private static void WriteToFileTransactions(object obj)
        {
            BalanceLastMinute = 0;
            listTransactions.RemoveAll(TimesMoreThanOneMinute);
            string path = "Transaction.log";
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    streamWriter.WriteLine(DateTime.Now.ToShortDateString());
                    foreach (var item in listTransactions)
                    {
                        streamWriter.WriteLineAsync(item.ToString());
                        BalanceLastMinute += item.WrittenOffFunds;
                    }
                }
            }
            catch (Exception e)
            {
            }
        }

        private static void WrittenOfMoney(object obj)
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
            string path = "Transaction.log";
            using (StreamReader streamReader = new StreamReader(path))
            {
                string input;
                Console.WriteLine($"Date: {streamReader.ReadLine()}");
                if((input = streamReader.ReadLine())==null)
                    Console.WriteLine("One minute has not passed yet, please try a little later");
                else
                    Console.WriteLine(input);
                while ((input = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                }
            }
        }
    }
}
