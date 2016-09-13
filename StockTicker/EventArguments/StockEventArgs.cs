using StockTicker.Models;
using System;

namespace StockTicker.EventArguments
{
    public class StockEventArgs : EventArgs
    {
        public StockBase StockItem { get; set; }

        public StockEventArgs(StockBase stockItem)
        {
            StockItem = stockItem;
        }
    }
}