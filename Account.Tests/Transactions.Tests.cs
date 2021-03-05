using NUnit.Framework;
using System;

namespace Account.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1_Depositing_300_should_return_400_balance()
        {
            var transaction = new Transactions(100,100);
            transaction.Deposit(300);
            Assert.AreEqual(400,transaction.Balance);
        }

        [Test]
        public void Test2_Withdrawing_300_Throws_OutOfRangeEx()
        {
            var transaction = new Transactions(100,100);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                transaction.Withdraw(300);
            });
        }

        [Test]
        public void Test3_should_return_20_after_Withdrawing_80()
        {
            var transaction = new Transactions(0,100);
            transaction.Withdraw(80);
            Assert.AreEqual(20,transaction.Balance);
        }
    }
}