using Domain.Entities;
using FluentValidation;

namespace Domain.Validations.Validators.Entities;

/// <summary>
/// Валидатор для служебной сущности OrderInstrument
/// </summary>
public class OrderInstrumentValidator : AbstractValidator<OrderInstrument>
{
    public OrderInstrumentValidator()
    {
        RuleFor(d => d.InstrumentId)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError);
        
        RuleFor(d => d.Instrument)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError);
        
        RuleFor(d => d.OrderId)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError);
        
        RuleFor(d => d.Order)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError);

        RuleFor(d => d.Amount)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .GreaterThanOrEqualTo(0).WithMessage(ValidationMessages.NegativeOrZeroNumberError);
        
        RuleFor(d => d.Price)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .GreaterThan(0).WithMessage(ValidationMessages.NegativeOrZeroNumberError)
            .PrecisionScale(10, 2, true).WithMessage(ValidationMessages.DecimalPlacesError);
    }
}