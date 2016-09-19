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
        /// Simulates regular stock prices change from a third party
        /// </summary>
        private void MonitorStockPrices()
        {
            Task monitor = Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    foreach (var stockItem in StockItems)
                    {
                        stockItem.GenerateNextPrice();
                        UpdatePrice(stockItem);
                    }
                    await Task.Delay(1000);
                }

            }, TaskCreationOptions.LongRunning);
        }
    }
}