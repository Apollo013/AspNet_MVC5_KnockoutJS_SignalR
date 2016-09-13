using System;

namespace StockTicker.Models
{
    public class StockBase
    {
        private static Random random = new Random();
        private const double min = 0.0;
        private const double max = 100.1;

        public string Name { get; set; }
        public double Price
        {
            get
            {
                return random.NextDouble() * (max - min) + min;
            }
        }

        public StockBase(string name)
        {
            Name = name;
        }
    }
}