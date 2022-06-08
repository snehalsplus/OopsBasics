using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDemon
{
    internal class BankAccount
    {
        private readonly decimal _minimumbalance;
        public string Accountnumber { get; }
        public string Owner { get; set; }
        public decimal Balance {
            get
            {
                decimal balance = 0;    
                foreach (var item in _transactions)
                {
                    balance = balance + item.Amount;                    
                }
                return balance;
            }            
        }

        private static int Number = 1258456925;
        private List<Transactions> _transactions = new List<Transactions>();

        public BankAccount(string Name,decimal initalBalance) : this(Name, initalBalance, 0) { }

        public BankAccount(string Name, decimal initalBalance,decimal minimumbal)
        {
            this.Owner = Name;
            this._minimumbalance = minimumbal;
            if(initalBalance > 0)
            {
                MakeDeposite(initalBalance, DateTime.Now, "Inital Balance1");
                this.Accountnumber = Number.ToString();
                Number++;
            }
            
        }
        public virtual void PerformMonthendTransaction()
        {

        }         
     

        public void MakeDeposite(decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount),"Amount Deposite must be positive");  
            }
            var deposite = new Transactions(amount, date, note);
            _transactions.Add(deposite);    
        }

        public void MakeWithdraw (decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }

            Transactions? overdraftchk = CheckwithdrawLimit(Balance - amount < _minimumbalance);                          
             var withdrawal = new Transactions(-amount, date, note);
            _transactions.Add(withdrawal);
        }

        protected virtual Transactions? CheckwithdrawLimit(bool isOverdraft) => isOverdraft ? new Transactions(-20, DateTime.Now, "Extra chages applied") : default;
       
        public string GetAccountHistory()
        {
            var reports = new StringBuilder();
            reports.AppendLine("Date\t\t\tAmount\t\tNote");
            foreach(var transaction in _transactions)
            {
                reports.AppendLine($"{transaction.Date}\t{transaction.Amount}\t\t{transaction.Notes}");
            }
            return reports.ToString();  
        }

        
    }
}
