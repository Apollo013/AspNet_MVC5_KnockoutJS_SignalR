using System;

namespace StockTicker.Services
{
    public interface IStockExchangeService<TEntity, TEventArgs>
    {
        event EventHandler<TEventArgs> StockPriceChanged;
        void Receive(TEntity item);
        void Add(string name);
    }
}
