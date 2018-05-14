using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Car
    {
        public string Identifier { get; set; }

        public double Balance { get; set; }

        public CarType CarType { get; set; }

        public void TopUpBalance(double totalMoney)
        {
            if (totalMoney > 0)
                Balance += totalMoney;
        }
    }
}
