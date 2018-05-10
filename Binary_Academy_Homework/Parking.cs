using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Academy_Homework
{
    class Parking
    {
        private static readonly Lazy<Parking> lazy = new Lazy<Parking>(() => new Parking());
        //        Parking - данный класс при инициализации использует настройки описанные в классе Settings:
        public static Parking Instance { get { return lazy.Value; } }

        private Parking()
        {
        }

        static List<Car> listCars;

        static List<Transaction> listTransactions;

        static double Balance;
    }
}
