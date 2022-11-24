using StocksAnalysis.ViewModels;
using StocksAnalysis.Services;

namespace StocksAnalysis;

public class ServiceLocator
{
    private IServiceProvider _serviceProvider;

   //public StockNamePageViewModel StockNamePageViewModel =>
       // _serviceProvider.GetService<StockNamePageViewModel>();

    public ServiceLocator()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddSingleton<IStockStorage, StockStorage>();
        serviceCollection.AddSingleton<IPreferenceStorage, PreferenceStorage>();

        //serviceCollection.AddSingleton<IStockNameService, StockNameService>();
        serviceCollection.AddSingleton<StockNamePageViewModel>();

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }
}