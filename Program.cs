namespace BankDemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bankaccount = new BankAccount("Snehal",1000);
            Console.WriteLine($"Account {bankaccount.Accountnumber}, Name {bankaccount.Owner}, opened account with inital amount ${bankaccount.Balance}");

            bankaccount.MakeWithdraw(500, DateTime.Now, "Shopping");
            Console.WriteLine($"{bankaccount.Balance}");

            var giftv = new GiftCardAccount("From HDFC Bank", 100, 50);
            giftv.MakeWithdraw(20,DateTime.Now, "Coffee purchase");
            giftv.PerformMonthendTransaction();
            Console.WriteLine(giftv.GetAccountHistory());
        

            var savings = new InterestEarningAccount("savings account", 10000);
            savings.MakeDeposite(750, DateTime.Now, "save some money");
            savings.MakeDeposite(1250, DateTime.Now, "Add more savings");
            savings.MakeWithdraw(250, DateTime.Now, "Needed to pay monthly bills");
            savings.PerformMonthendTransaction();
            Console.WriteLine(savings.GetAccountHistory());

            var lineOfCredit = new LineOfCreditAccount("line of credit", 0,2000);
            // How much is too much to borrow?
            lineOfCredit.MakeWithdraw(1000m, DateTime.Now, "Take out monthly advance");
            lineOfCredit.MakeDeposite(50m, DateTime.Now, "Pay back small amount");
            lineOfCredit.MakeWithdraw(5000m, DateTime.Now, "Emergency funds for repairs");
            lineOfCredit.MakeDeposite(150m, DateTime.Now, "Partial restoration on repairs");
            lineOfCredit.PerformMonthendTransaction();
            Console.WriteLine(lineOfCredit.GetAccountHistory());

               BankAccount invalidTransaction;
               try
               {
                   invalidTransaction = new BankAccount("Invalid", -10);
               }
               catch(ArgumentOutOfRangeException ex)
               {
                   Console.WriteLine("Exception caught");
                   Console.WriteLine(ex.ToString());
                   return;
               }

            Console.WriteLine(bankaccount.GetAccountHistory());
        }
    }
}