using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Academy_Homework
{
    static class Menu
    {
        private static Parking parking;

        static Menu()
        {
            parking = new Parking();
        }

        public static void DoWork()
        {
            Console.Clear();
            Console.WriteLine("Please enter a number of command, which you would like perform(1-9)");
            Console.WriteLine("1 - Add a car\n2 - Remove a car\n3 - Get the transactons\n4 - Get the balance of parking\n5 - Get a count of free space in parking\n" +
                "6 - Get a count of occupied parking spaces\n7 - Get the balance for the last minute\n8 - Refill the balance of the machine\n9 - Exit");
            try
            {
                char command = Console.ReadKey().KeyChar;

                switch (command)
                {
                    case '1':
                        AddCar();
                        break;
                    case '2':
                        RemoveCar();
                        break;
                    case '3':
                        GetTransactions();
                        break;
                    case '4':
                        GetBalance();
                        break;
                    case '5':
                        GetCountFreeSpace();
                        break;
                    case '6':
                        GetCountOcupiedSpace();
                        break;
                    case '7':
                        GetBalanceLastMinute();
                        break;
                    case '8':
                        RefillBalanceMachine();
                        break;
                    case '9':
                        Environment.Exit(0);
                        break;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nInput data incorrect please try again");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            DoWork();
        }

        private static void AddCar()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("Please enter an identifier of car");
                string identifier = Console.ReadLine().ToString();
                if (identifier == String.Empty)
                    throw new Exception("Identifier is empty");
                Console.WriteLine("Please enter an balance of car");
                double balance = Convert.ToDouble(Console.ReadLine());
                if (balance <= 0)
                    throw new Exception("Balance less than 0");
                Console.WriteLine("Please choose  a number type of car");
                Console.WriteLine("1 - Truck\n2 - Passenger\n3 - Motorcycle\n4 - Bus");
                CarType carType;
                int carTypeNum = Convert.ToInt32(Console.ReadLine());
                if (carTypeNum >= 1 && carTypeNum <= 4)
                    carType = (CarType)(carTypeNum - 1);
                else
                {
                    throw new Exception("Type of car incorrect");
                }
                bool result = parking.AddCar(new Car() { Identifier = identifier, Balance = balance, CarType = carType });

                if (result)
                    Console.WriteLine("Parking was added");
                else
                    Console.WriteLine("Sorry, parking don`t have a free parking place");
            }
            catch (Exception e)
            {
                Console.WriteLine("incorrect date please try again");
            }


            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            DoWork();
        }

        private static void RemoveCar()
        {
            Console.Clear();
            Console.WriteLine("Please enter an identifier of car");
            string identifier = Console.ReadLine().ToString();
            bool result = parking.RemoveCar(identifier);
            if (result)
                Console.WriteLine("Car was removed");
            else
                Console.WriteLine("Car wasn`t removed, because identifier not found");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            DoWork();
        }

        private static void GetTransactions()
        {
            Console.Clear();
            Console.WriteLine("The transactions: ");
            parking.GetTransactions();
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            DoWork();
        }

        private static void GetBalance()
        {
            Console.Clear();
            Console.WriteLine("The parking balance: " + Parking.Balance);
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            DoWork();
        }

        private static void GetCountFreeSpace()
        {
            Console.Clear();
            Console.WriteLine("Count free parking space: " + parking.CountFreeParkingSpace);
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            DoWork();
        }

        private static void GetCountOcupiedSpace()
        {
            Console.Clear();
            Console.WriteLine("Count of occupied parking spaces: " + (Settings.ParkingSpace - parking.CountFreeParkingSpace));
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            DoWork();
        }

        private static void GetBalanceLastMinute()
        {
            Console.Clear();
            Console.WriteLine("The parking balance of the last minute: " + Parking.BalanceLastMinute);
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            DoWork();
        }

        private static void RefillBalanceMachine()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("Please enter the sum");
                double sum = Convert.ToDouble(Console.ReadLine());
                if (sum <= 0)
                    throw new Exception("Sum for car less than 0");
                Console.WriteLine("Please enter the car identifier");
                string identifier = Console.ReadLine();
                if (identifier == String.Empty)
                    throw new Exception();
                Car car2 = Parking.listCars.FindLast(car => car.Identifier == identifier);

                if (car2 != null)
                {
                    car2.TopUpBalance(sum);
                    Console.WriteLine($"The balance of car {identifier} was top up");
                }
                else
                {
                    Console.WriteLine($"The car with identifier {identifier} not found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Incorrect date please try again");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            DoWork();
        }
    }
}
