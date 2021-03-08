using System;
using System.Collections.Generic;
using System.Linq;

namespace Account
{
    public class CurrencyService
    {
        List<Currency> currencies;
        public CurrencyService()
        {
            currencies = new List<Currency>{
                new Currency(1.0,"default"),
                new Currency(4.5517,"euro"),
                new Currency(5.2780,"pound"),
                new Currency(3.8198,"usdolar")
            };

        }
        
        public virtual double GetRate(string name)
        {
            double rate = 1;
            foreach(var x in currencies.Where(n=>n.name==name)){
                rate = x.rate;
            }
            return rate;
        }
    }

    public class Currency
    {
        public double rate { get; set; }
        public string name { get; set; }
        
        public Currency(double rate,string name)
        {
            this.rate = rate;
            this.name = name;
        }
    }

}