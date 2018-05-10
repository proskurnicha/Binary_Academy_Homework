using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Academy_Homework
{
    class Car
    {
        public int Identifier { get; set; }

        public double Balance { get; set; }

        public CarType CarType { get; set; }

        public void TopUpBalance(double totalMoney)
        {
            if (totalMoney > 0)
                Balance += totalMoney;
        }
    }
}
