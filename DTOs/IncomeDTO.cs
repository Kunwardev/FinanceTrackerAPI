namespace FinanceTrackerAPI.DTO;
using FinanceTrackerAPI.Extensions;

public class IncomeDTO
{
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