using StockTicker.EventArguments;
using StockTicker.Models;
using System;
using System.Collections.Generic;

namespace StockTicker.Services
{
    /// <summary>
    /// Abstract Service
    /// </summary>
    public abstract class StockExchangeServiceBase : IStockExchangeService<StockBase, StockEventArgs>
    {
        protected List<string> Tickers = new List<string>();
        public event EventHandler<StockEventArgs> StockPriceChanged;

        public void Add(string name)
        {
            Tickers.Add(name);
        }

        public void Receive(StockBase item)
        {
            if (item == null) { return; }
            StockPriceChanged?.Invoke(this, new StockEventArgs(item));
        }
    }
}