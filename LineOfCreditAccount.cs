using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemon
{
    internal class LineOfCreditAccount : BankAccount
    {
       // private readonly decimal creditAmt;
        public LineOfCreditAccount(string Name, decimal initalBalance,decimal creditAmt) : base(Name, initalBalance, -creditAmt)
        {
        }

        public override void PerformMonthendTransaction()
        {
            decimal interest = -Balance * 0.07m;
            MakeWithdraw(interest, DateTime.Now, "Charge applied Monthly1");            
        }

    }
}
