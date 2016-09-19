using System;

namespace StockTicker.Models
{
    public class StockBase
    {
        private static Random random = new Random();
        private const double min = 0.0;
        private const double max = 100.1;
        private static int currentid = 0;

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public StockBase(int id, string name)
        {
            Name = name;
            Id = id;
        }

        public void GenerateNextPrice()
        {
            Price = random.NextDouble() * (max - min) + min;
        }
    }
}