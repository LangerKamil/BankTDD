using System;

namespace Account
{
    public class Transactions
    {
        private double debit = 100;
        private double balance = 100;

        public Transactions(double balance, double debit)
        {
            this.balance = balance;
            this.debit = debit;
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

    }
}
