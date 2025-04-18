using FinanceTrackerAPI.DTO;
using FluentValidation;

namespace FinanceTrackerAPI.Validator;

public class UserDTOValidator : AbstractValidator<UserDTO>
{
    public UserDTOValidator()
    {
        RuleFor(x => x.name.Length).GreaterThan(7);
    }
}