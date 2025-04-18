namespace FinanceTrackerAPI.Models;
using FinanceTrackerAPI.Extensions;

public class Income{
    public int id{ get; set;}
    private string _source;
    public string source
    {
        get => _source;
        set => _source = value;
    }
    public decimal amount{get; set;}
    public DateTime datetime{get; set;}
}
