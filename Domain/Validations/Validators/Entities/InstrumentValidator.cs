using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validations.Validators.Entities;

/// <summary>
/// Валидатор для сущности Instrument
/// </summary>
public class InstrumentValidator : AbstractValidator<Instrument>
{
    public InstrumentValidator()
    {
        RuleFor(d => d.Name)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .MinimumLength(2).WithMessage(ValidationMessages.MinimumLengthError)
            .MaximumLength(30).WithMessage(ValidationMessages.MaximumLengthError)
            .Matches(RegexPatterns.LettersPattern).WithMessage(ValidationMessages.OnlyLettersError);

        RuleFor(d => d.Category)
            .NotEqual(Category.None).WithMessage(ValidationMessages.EnumError);
        
        RuleFor(d => d.Price)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .GreaterThan(0).WithMessage(ValidationMessages.NegativeOrZeroNumberError)
            .PrecisionScale(10, 2, true).WithMessage(ValidationMessages.DecimalPlacesError);
    }
}