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
        /// <summary>
        /// A list of stock items to check for price updates
        /// </summary>
        protected List<StockBase> StockItems = new List<StockBase>();

        /// <summary>
        /// Event handler that notifies users when a stock price has changed
        /// </summary>
        public event EventHandler<StockEventArgs> StockPriceChanged;

        /// <summary>
        /// Adds a new stock item that we want to regular price updates for
        /// </summary>
        /// <param name="item"></param>
        public void Add(StockBase item)
        {
            StockItems.Add(item);
        }

        /// <summary>
        /// Updates a stockitem with the latest price and notifies and subscribers
        /// </summary>
        /// <param name="item"></param>
        public void UpdatePrice(StockBase item)
        {
            if (item == null) { return; }
            StockPriceChanged?.Invoke(this, new StockEventArgs(item));
        }
    }
}