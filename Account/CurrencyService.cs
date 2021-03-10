using System.Collections.Generic;
using System.Linq;
using System;

namespace Account
{
    public class CurrencyService
    {
        private List<Currency> currencies;
        private string currencyName;
        public CurrencyService(string currencyName)
        {
            string name = currencyName.ToLower();
            if(name==null)
            {
                throw new NullReferenceException("Can't be empty");
            }
            else if(name!="euro" && name!="pound" && name!="usdolar")
            {
            System.Console.WriteLine(name);

                throw new ArgumentOutOfRangeException("Invalid argument (EURO,POUND,USDOLAR only)");
            }
            else if(currencyName.Count()>10)
            {
                throw new ArgumentOutOfRangeException("Can't be longer than 10 characters");
            }
            this.currencyName = currencyName;

            currencies = new List<Currency>{
                //new Currency(1.0,"default"),
                new Currency(4.5517,"euro"),
                new Currency(5.2780,"pound"),
                new Currency(3.8198,"usdolar")
            };

        }
        
        public virtual double GetRate()
        {
            double rate = 1;
            foreach(var x in currencies.Where(n=>n.name==currencyName)){
                rate = x.rate;
            }
            return rate;
        }
    }

    public class Currency
    {
        public double rate { get; }
        public string name { get; }
        
        public Currency(double rate,string name)
        {
            this.rate = rate;
            this.name = name;
        }
    }

}