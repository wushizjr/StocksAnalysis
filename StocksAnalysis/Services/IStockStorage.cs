using StocksAnalysis.Models;
using System.Linq.Expressions;

namespace StocksAnalysis.Services;
public interface IStockStorage
{
    bool IsInitialized { get; }

    Task InitializeAsync();

    Task<Stock> GetStockAsync(string code);

    Task<IEnumerable<Stock>> GetStockAsync(
        Expression<Func<Stock, bool>> where, int skip, int take);
}