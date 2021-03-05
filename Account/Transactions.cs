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
            if(amount<0)
            {
                throw new ArgumentOutOfRangeException("Less than zero");
            }
            balance += amount;
        }

        public void Withdraw(int amount)
        {
            if(amount>(balance+debit))
            {
                throw new ArgumentOutOfRangeException("Limit exceeded");
            }
            balance = balance - amount;
        }

    }
}
