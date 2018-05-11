using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Academy_Homework
{
    class Transaction
    {
        public DateTime DateTransaction { get; set; }

        public string IdentifierCar { get; set; }

        public double WrittenOffFunds { get; set; }

        public override string ToString()
        {
            return String.Format("{0, 10}|{1,8}|{2,10}", WrittenOffFunds, IdentifierCar, DateTransaction.ToLongTimeString());
        }
    }
}
