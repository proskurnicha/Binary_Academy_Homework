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
            return WrittenOffFunds + " " + IdentifierCar + " " + DateTransaction.ToLongTimeString();
        }
    }
}
