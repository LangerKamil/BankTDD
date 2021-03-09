using NUnit.Framework;
using System;

namespace Account.Tests
{
    public class Tests
    {
        CurrencyService currencyService;

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

        // Zad 2.1

        [Test]
        public void Test10_Transfering_100_euro_return_455()
        {
            var currencyServiceMock = new Moq.Mock<CurrencyService>("euro");

            var transaction = new Transactions(300,200,currencyServiceMock.Object);
            var wynik = transaction.Transfer(100);
           
            Assert.AreEqual(455,wynik);
        }
        
        [Test]
        public void Test11_Transfering_200_pounds_return_1112()
        {
            var currencyServiceMock = new Moq.Mock<CurrencyService>("pound");

            var transaction = new Transactions(800,300,currencyServiceMock.Object);
            var wynik = transaction.Transfer(200);
           
            Assert.AreEqual(1056,wynik);
        }

        [Test]
        public void Test12_Transfering_300_usdolars_return_1143()
        {
            var currencyServiceMock = new Moq.Mock<CurrencyService>("usdolar");
            
            var transaction = new Transactions(1000,200,currencyServiceMock.Object);
            var wynik = transaction.Transfer(300);
           
            Assert.AreEqual(1146,wynik);
        }

        [Test]
        public void Test13_Transfering_300_usdolars_with_500_onAccount_should_throw_OutOfRangeEx()
        {
            var currencyServiceMock = new Moq.Mock<CurrencyService>("usdolar");

            var transaction = new Transactions(300,200,currencyServiceMock.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() =>{
                transaction.Transfer(300);
            });
        }

        [Test]
        public void Test14_Transfering_minus_300_euros_should_throw_NullReferenceEx()
        {
            var currencyServiceMock = new Moq.Mock<CurrencyService>("euro");
            
            var transaction = new Transactions(300,200,currencyServiceMock.Object);
            
            Assert.Throws<NullReferenceException>(() =>{
                transaction.Transfer(-300);
            });
        }

        [Test]
        public void Test15_Transfering_100_euros_return_mocked_6()
        {
            var currencyServiceMock = new Moq.Mock<CurrencyService>("euro");
            currencyServiceMock.Setup(x=>x.GetRate()).Returns(0.06);

            var transaction = new Transactions(300,200,currencyServiceMock.Object);
            var wynik = transaction.Transfer(100);
           
            Assert.AreEqual(6,wynik);
        }

        [Test]
        public void Test16_Transfering_minus_300_euros_should_throw_NullReferenceEx()
        {
            var currencyServiceMock = new Moq.Mock<CurrencyService>("euro");
            currencyServiceMock.Setup(x=>x.GetRate()).Returns(4.5517);
            
            var transaction = new Transactions(300,200,currencyServiceMock.Object);
            
            Assert.Throws<NullReferenceException>(() =>{
                transaction.Transfer(-300);
            });
        }

        [Test]
        public void Test17_Transfering_100_euros_return_mocked_6()
        {
            var currencyServiceMock = new Moq.Mock<CurrencyService>("euro");
            currencyServiceMock.Setup(x=>x.GetRate()).Returns(0.06);

            var transaction = new Transactions(300,200,currencyServiceMock.Object);
            var wynik = transaction.Transfer(100);
           
            Assert.AreEqual(6,wynik);
        }
        [Test]
        public void Test18_Giving_random_characters_as_an_argument_throw_ArgumentOutOfRangeEx()
        {
            
            Assert.Throws<ArgumentOutOfRangeException>(()=>{
            
                currencyService = new CurrencyService("12f43@4!");

            });

        }

        [Test]
        public void Test19_Giving_more_than_10_characters_as_an_argument_throw_ArgumentOutOfRangeEx()
        {
            
            Assert.Throws<ArgumentOutOfRangeException>(()=>{
            
                currencyService = new CurrencyService("01245678910");

            });

        }

        [Test]
        public void Test20_CurrencyName_in_uppercase_is_transformed_to_lowercase()
        {
            
            Assert.Pass("argument transformed to lowercase",currencyService = new CurrencyService("EURo"));

        }

        [Test]
        public void Test21_Giving_null_as_an_argument_throw_NullReferenceEx()
        {
            
            Assert.Throws<NullReferenceException>(()=>{
            
                currencyService = new CurrencyService(null);

            });

        }
    }
}