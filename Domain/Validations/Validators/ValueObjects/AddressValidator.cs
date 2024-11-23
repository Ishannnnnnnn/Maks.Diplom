using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validations.Validators.ValueObjects;

/// <summary>
/// Валидатор для значимого объекта Address
/// </summary>
public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(d => d.City)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .MinimumLength(2).WithMessage(ValidationMessages.MinimumLengthError)
            .MaximumLength(50).WithMessage(ValidationMessages.MaximumLengthError);
        
        RuleFor(d => d.Street)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .MinimumLength(3).WithMessage(ValidationMessages.MinimumLengthError)
            .MaximumLength(100).WithMessage(ValidationMessages.MaximumLengthError);

        RuleFor(d => d.HouseNumber)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .GreaterThan(0).WithMessage(ValidationMessages.NegativeOrZeroNumberError);
    }
}