using Microsoft.AspNet.SignalR;
using StockTicker.EventArguments;
using StockTicker.Models;
using StockTicker.Services;

namespace StockTicker.Hubs
{
    public class StockTickerHub : Hub
    {
        private StockExchangeServiceBase _service;

        public StockTickerHub()
        {
            _service = new StockExchangeService();
            _service.StockPriceChanged += UpdatePrice;
        }

        /// <summary>
        /// Add new ticker to get stock prices for, and add connection_id to ticker group
        /// </summary>
        /// <param name="ticker"></param>
        public void AddTicker(int id, string name)
        {
            _service.Add(new StockBase(id, name));
        }

        /// <summary>
        /// Notify clients who want to know about this stock item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void UpdatePrice(object sender, StockEventArgs args)
        {
            Clients.All.notifyStockChange(args.StockItem);
        }
    }
}