using StockTicker.Models;
using System.Threading.Tasks;

namespace StockTicker.Services
{
    /// <summary>
    /// Stock exchange simulator
    /// </summary>
    public class StockExchangeService : StockExchangeServiceBase
    {
        public StockExchangeService()
        {
            MonitorStockPrices();
        }

        /// <summary>
        /// Simulates stock prices change
        /// </summary>
        private void MonitorStockPrices()
        {
            Task monitor = Task.Factory.StartNew(async () =>
            {
                foreach (var ticker in Tickers)
                {
                    Receive(new StockBase(ticker));
                }
                await Task.Delay(500);
            }, TaskCreationOptions.LongRunning);
        }
    }
}