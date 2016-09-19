using System;

namespace StockTicker.Services
{
    public interface IStockExchangeService<TEntity, TEventArgs>
    {
        event EventHandler<TEventArgs> StockPriceChanged;
        void UpdatePrice(TEntity item);
        void Add(TEntity item);
    }
}
