using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemon
{
    internal class InterestEarningAccount : BankAccount
    {
        public InterestEarningAccount(string Name, decimal initalBalance) : base(Name, initalBalance)
        {
            
        }
        public override void PerformMonthendTransaction()
        {
            if(Balance > 500m)
            {
                decimal interest = Balance * 0.02m;
                MakeDeposite(Balance, DateTime.Now, "Interest Amount1");
            }
        }
    }
}
