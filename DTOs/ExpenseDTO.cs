namespace FinanceTrackerAPI.DTO;
using FinanceTrackerAPI.Extensions;

public class ExpenseDTO
{
    public int id {get; set;}

    private string _category;
    public string category
    {
        get => _category?.EscapeSingleQuote();
        set => _category = value?.EscapeSingleQuote();
    }

    private string _description;
    public string description
    {
        get => _description?.EscapeSingleQuote();
        set => _description = value?.EscapeSingleQuote();
    }
    public decimal amount{get;set;}
    public DateTime datetime{get;set;}
    
}