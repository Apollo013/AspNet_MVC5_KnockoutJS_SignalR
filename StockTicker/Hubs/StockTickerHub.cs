using Microsoft.AspNet.SignalR;
using StockTicker.EventArguments;
using StockTicker.Services;

namespace StockTicker.Hubs
{
    public class StockTickerHub : Hub
    {
        private StockExchangeServiceBase _service;

        public StockTickerHub(StockExchangeServiceBase service)
        {
            _service = service;
            _service.StockPriceChanged += UpdatePrice;
        }

        /// <summary>
        /// Add new ticker to get stock prices for, and add connection_id to ticker group
        /// </summary>
        /// <param name="ticker"></param>
        public void AddTicker(string ticker)
        {
            string connectionId = Context.ConnectionId;
            Groups.Add(connectionId, ticker); // Create a new group for stock ticker
            _service.Add(ticker);
        }

        /// <summary>
        /// Notify clients who want to know about this stock item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void UpdatePrice(object sender, StockEventArgs args)
        {
            Clients.Group(args.StockItem.Name).notifyStockChange(args.StockItem);
        }
    }
}