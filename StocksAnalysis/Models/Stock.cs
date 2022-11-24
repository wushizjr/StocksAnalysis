namespace StocksAnalysis.Models;

[SQLite.Table("stock name")]
public class Stock
{
    [SQLite.Column("Code")]
    public string Code { get; set; } = string.Empty;
    [SQLite.Column("Id")]
    public string Name { get; set; } = string.Empty;
    [SQLite.Column("StatDate")]
    public DateTime StatDate { get; set; }
    [SQLite.Column("EndPrice")]
    public double EndPrice { get; set; }
    [SQLite.Column("ChangeRatio")]
    public double ChangeRatio { get; set; }
}