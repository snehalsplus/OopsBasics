using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemon
{
    internal class Transactions
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }

        public Transactions(decimal amount, DateTime datee, string note)
        {
            Amount = amount;
            Date = datee;
            Notes = note;
        }
    }
}

