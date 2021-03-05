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
        public void Test1_Depositing_300_should_return_400_with_100_stored()
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
        public void Test3_should_return_minus_80_after_Withdrawing_80_with_just_100_debit()
        {
            var transaction = new Transactions(0,100);
            transaction.Withdraw(80);
            Assert.AreEqual(-80,transaction.Balance);
        }

        [Test]
        public void Test4_should_return_minus_50_after_Withdrawing_550_with_500_stored()
        {
            var transaction = new Transactions(500,200);
            transaction.Withdraw(550);
            Assert.AreEqual(-50,transaction.Balance);
        }

        [Test]
        public void Test5_Depositing_0_throws_NullReferenceEx()
        {
            var transaction = new Transactions(500,200);
            Assert.Throws<NullReferenceException>(() =>
            {
                transaction.Deposit(0);
            });
        }

        [Test]
        public void Test6_Depositing_minus_200_throws_NullReferenceEx()
        {
            var transaction = new Transactions(500,200);
            Assert.Throws<NullReferenceException>(() =>
            {
                transaction.Deposit(-200);
            });
        }

        [Test]
        public void Test7_Depositing_11mln_throws_OutOfRangeEx() // the limit is 10mln
        {
            var transaction = new Transactions(500,200);
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                transaction.Deposit(11000000);
            });
        }
        [Test]
        public void Test8_Withdrawing_0_throws_NullReferenceEx()
        {
            var transaction = new Transactions(500,200);
            Assert.Throws<NullReferenceException>(() =>
            {
                transaction.Withdraw(0);
            });
        }

        [Test]
        public void Test9_Withdrawing_minus_100_throws_NullReferenceEx()
        {
            var transaction = new Transactions(500,200);
            Assert.Throws<NullReferenceException>(() =>
            {
                transaction.Withdraw(-100);
            });
        }
    }
}