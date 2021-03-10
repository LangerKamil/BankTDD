using System;

namespace Account
{
    public class Transactions
    {
        CurrencyService currencyService;
        private double debit = 100;
        private double balance = 100;

        public Transactions(double balance, double debit)
        {
            this.balance = balance;
            this.debit = debit;
        }       
        public Transactions(double balance, double debit, CurrencyService currencyService)
        {
            this.balance = balance;
            this.debit = debit;
            this.currencyService = currencyService;
        }

        public double Balance
        {
            get { return balance;}
        }
        public void Deposit(int amount)
        {
            if(amount<0 || amount==0)
            {
                throw new NullReferenceException("Can't be zero or negative");
            }
            else if(amount>10000000)
            {
                throw new ArgumentOutOfRangeException("Can't deposit more than 10mln at once");
            }
            balance += amount;
        }

        public void Withdraw(int amount)
        {
            if(amount>balance)
            {
                if(amount>(balance+debit))
                {
                    throw new ArgumentOutOfRangeException("Limit exceeded");
                }
                debit -= amount;
            }
            else if(amount<0 || amount==0)
            {
                throw new NullReferenceException("Can't be zero or negative");
            }
            balance -= amount;
        }

        public double Transfer(double amount)
        {
            var rate = currencyService.GetRate();

            double exchanged = Math.Round(amount * rate);
            if(exchanged>balance)
            {
                if(exchanged>(balance+debit))
                {
                    throw new ArgumentOutOfRangeException("Not enough money to transfer");
                }
                debit -= exchanged;
            }
            else if(exchanged<0 || exchanged==0)
            {
                throw new NullReferenceException("Can't be zero or negative");
            }
            balance -= exchanged;

            return exchanged;
        }

    }
}
