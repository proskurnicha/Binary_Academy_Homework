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
            Console.WriteLine("Please enter a number of command, which you would like perform");
            Console.WriteLine("1 - Add a car\n2 - Remove a car\n3 - Get the transactons\n4 - Get the balance of parking\n5 - Get a count of free space in parking\n6 - Get the balance for the last minute\n7 - Refill the balance of the machine\n8 - Exit");
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
                    GetBalanceLastMinute();
                    break;
                case '7':
                    RefillBalanceMachine();
                    break;
                case '8':
                    //Console. Exit();
                    break;
                default:
                    break;
            }

        }

        private static void AddCar()
        {
            Console.Clear();
            Console.WriteLine("Please enter an identifier of car");
            string identifier = Console.ReadLine().ToString();
            Console.WriteLine("Please enter an balance of car");
            double balance = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please choose  a number type of car");
            Console.WriteLine("1 - Truck\n2 - Passenger\n3 - Motorcycle\n4 - Bus");
            CarType carType;
            int carTypeNum = Convert.ToInt32(Console.ReadLine());
            if (carTypeNum >= 1 && carTypeNum <= 4)
                carType = (CarType)(carTypeNum - 1);
            else
            {
                Console.WriteLine("Data is uncorrect, identifier - 1");
                carType = CarType.Truck;
            }

            bool result = parking.AddCar(new Car() { Identifier = identifier, Balance = balance, CarType = carType });

            if (result)
                Console.WriteLine("Parking was added");
            else
                Console.WriteLine("Sorry, parking don`t have a free parking place");
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
            if(result)
                Console.WriteLine("Car was removed");
            else
                Console.WriteLine("Car wasn`t removed ");
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
            Console.WriteLine("Please enter the sum");
            double  sum = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter the car identifier");
            string identifier = Console.ReadLine();
            Car car2 =  Parking.listCars.FindLast(car => car.Identifier == identifier);
            car2.TopUpBalance(sum);
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            DoWork();
        }
    }
}
