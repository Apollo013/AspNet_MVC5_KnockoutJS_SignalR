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
        protected List<StockBase> StockItems = new List<StockBase>();
        public event EventHandler<StockEventArgs> StockPriceChanged;

        public void Add(StockBase item)
        {
            StockItems.Add(item);
        }

        public void UpdatePrice(StockBase item)
        {
            if (item == null) { return; }
            StockPriceChanged?.Invoke(this, new StockEventArgs(item));
        }
    }
}