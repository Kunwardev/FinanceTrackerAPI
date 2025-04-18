namespace FinanceTrackerAPI.Profiles;

using AutoMapper;
using FinanceTrackerAPI.Models;
using FinanceTrackerAPI.DTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Income, IncomeDTO>();
        CreateMap<IncomeDTO, Income>();
        CreateMap<Expense, ExpenseDTO>();
        CreateMap<ExpenseDTO, Expense>();
    }
}