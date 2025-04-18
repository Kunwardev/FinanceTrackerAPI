using System.Data;
using FinanceTrackerAPI.DTO;
using FluentValidation;

namespace FinanceTrackerAPI.Validator;

public class IncomeDTOValidator : AbstractValidator<IncomeDTO>{
    public IncomeDTOValidator(){
        RuleFor(x => x.amount).GreaterThan(0);
        RuleFor(x => x.source).NotEmpty().MaximumLength(100);
        RuleFor(x => x.datetime).LessThanOrEqualTo(DateTime.Now);
    }
}