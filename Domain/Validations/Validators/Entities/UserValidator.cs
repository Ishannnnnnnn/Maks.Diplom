using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validations.Validators.Entities;

/// <summary>
/// Валидатор для сущности User
/// </summary>
public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(d => d.FullName)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError);
        
        RuleFor(d => d.Nickname)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .MinimumLength(2).WithMessage(ValidationMessages.MinimumLengthError)
            .MaximumLength(30).WithMessage(ValidationMessages.MaximumLengthError);
        
        RuleFor(d => d.Email)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .Matches(RegexPatterns.EmailPattern).WithMessage(ValidationMessages.EmailError);

        RuleFor(d => d.Password)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .MinimumLength(8).WithMessage(ValidationMessages.MinimumLengthError);
        
        RuleFor(d => d.Role)
            .NotEqual(Role.None).WithMessage(ValidationMessages.EnumError);
        
        RuleFor(d => d.Balance)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMessages.NegativeOrZeroNumberError);
        
        RuleFor(d => d.Purchases)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMessages.NegativeOrZeroNumberError);
        
        RuleFor(d => d.MoneySpend)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMessages.NegativeOrZeroNumberError);
    }
}