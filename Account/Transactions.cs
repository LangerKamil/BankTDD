using System;

namespace Account
{
    public class Transactions
    {
        private double debit = 100;
        private double balance = 100;
        private int currency = 1;
        private double rate = 1;

        public Transactions(double balance, double debit)
        {
            this.balance = balance;
            this.debit = debit;
        }       
        public Transactions(double balance, double debit, double rate)
        {
            this.balance = balance;
            this.debit = debit;
            this.rate = rate;
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

        public double InternationalTransfer(double amount)
        {
            double exchanged = Math.Round(amount * rate);
            balance -= exchanged;
            System.Console.WriteLine($"Transfering {exchanged}");
            return exchanged;
        }

    }
}
