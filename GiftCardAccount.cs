using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemon
{
    internal class GiftCardAccount : BankAccount
    {
        private readonly decimal _monthlyDeposite =0m;

        public GiftCardAccount(string Name, decimal initalBalance, decimal monthlyDeposite = 0) : base(Name, initalBalance)
            => _monthlyDeposite = monthlyDeposite;

        public override void PerformMonthendTransaction()
        {
            MakeDeposite(_monthlyDeposite, DateTime.Now, "Recieved Gift card1");
        }

    }
}
