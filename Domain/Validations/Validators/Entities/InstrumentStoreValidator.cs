using Domain.Entities;
using FluentValidation;

namespace Domain.Validations.Validators.Entities;

/// <summary>
/// Валидатор для служебной сущности InstrumentStore
/// </summary>
public class InstrumentStoreValidator : AbstractValidator<InstrumentStore>
{
    public InstrumentStoreValidator()
    {
        RuleFor(d => d.InstrumentId)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError);
        
        RuleFor(d => d.StoreId)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError);

        RuleFor(d => d.Amount)
            .NotNull().WithMessage(ValidationMessages.NullError);
    }
}