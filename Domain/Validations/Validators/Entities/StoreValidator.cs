using Domain.Entities;
using FluentValidation;

namespace Domain.Validations.Validators.Entities;

/// <summary>
/// Валидатор для сущности Store
/// </summary>
public class StoreValidator : AbstractValidator<Store>
{
    public StoreValidator()
    {
        RuleFor(d => d.Address)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError);
        
        RuleFor(d => d.Phone)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .Matches(RegexPatterns.PhonePattern).WithMessage(ValidationMessages.PhoneError);
    }
}