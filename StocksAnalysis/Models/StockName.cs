namespace StocksAnalysis.Models;

[SQLite.Table("stock name")]
public class StockName
{
    [SQLite.Column("Code")]
    public string Code { get; set; } = string.Empty;
    [SQLite.Column("Name")]
    public string Name { get; set; } = string.Empty;
}