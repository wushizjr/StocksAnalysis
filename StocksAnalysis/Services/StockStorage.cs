using SQLite;
using StocksAnalysis.Models;
using System.Linq.Expressions;

namespace StocksAnalysis.Services;
public class StockStorage : IStockStorage
{
    public const string DbName = "Code0-1500Data.sqlite3";

    public static readonly string StockDbPath =
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder
                .LocalApplicationData), DbName);

    private readonly IPreferenceStorage _preferenceStorage;

    public StockStorage(IPreferenceStorage preferenceStorage)
    {
        _preferenceStorage = preferenceStorage;
    }

    public bool IsInitialized =>
        _preferenceStorage.Get(StockStorageConstant.VersionKey, 0) ==
        StockStorageConstant.Version;

    public async Task InitializeAsync()
    {
        await using var dbFileStream =
            new FileStream(StockDbPath, FileMode.OpenOrCreate);
        await using var dbAssetStream =
            typeof(StockStorage).Assembly.GetManifestResourceStream(DbName);
        await dbAssetStream.CopyToAsync(dbFileStream);

        _preferenceStorage.Set(StockStorageConstant.VersionKey,
            StockStorageConstant.Version);
    }

    private SQLiteAsyncConnection? _connection;

    private SQLiteAsyncConnection Connection =>
        _connection ??= new SQLiteAsyncConnection(StockDbPath);

    public async Task<Stock> GetStockAsync(string code)
    {
        return await Connection.Table<Stock>()
            .FirstOrDefaultAsync(p => p.Code  == code);
    }

    public async Task<IEnumerable<Stock>> GetStockAsync(
        Expression<Func<Stock, bool>> where, int skip, int take) =>
        await Connection.Table<Stock>().Where(where).Skip(skip).Take(take)
            .ToListAsync();


    public async Task CloseAsync() => await Connection.CloseAsync();
}

public static class StockStorageConstant
{
    public const string VersionKey =
        nameof(StockStorageConstant) + "." + nameof(Version);

    public const int Version = 1;
}
