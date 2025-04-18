using System.Data;
using FinanceTrackerAPI.DTO;
using FluentValidation;

namespace FinanceTrackerAPI.Validator;

public class ExpenseDTOValidator : AbstractValidator<ExpenseDTO>{
    public ExpenseDTOValidator(){
        RuleFor(x => x.amount).GreaterThan(0);
        RuleFor(x => x.datetime).LessThanOrEqualTo(DateTime.Now);
    }
}