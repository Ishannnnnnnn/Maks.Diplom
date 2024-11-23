using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validations.Validators.ValueObjects;

/// <summary>
/// Валидатор для значимого объекта FullName
/// </summary>
public class FullNameValidator : AbstractValidator<FullName>
{
    public FullNameValidator()
    {
        RuleFor(d => d.Name)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .MinimumLength(2).WithMessage(ValidationMessages.MinimumLengthError)
            .MaximumLength(20).WithMessage(ValidationMessages.MaximumLengthError);
        
        RuleFor(d => d.Surname)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .MinimumLength(2).WithMessage(ValidationMessages.MinimumLengthError)
            .MaximumLength(20).WithMessage(ValidationMessages.MaximumLengthError);

        RuleFor(d => d.Patronymic)
            .NotNull().WithMessage(ValidationMessages.NullError)
            .NotEmpty().WithMessage(ValidationMessages.EmptyError)
            .MinimumLength(2).WithMessage(ValidationMessages.MinimumLengthError)
            .MaximumLength(20).WithMessage(ValidationMessages.MaximumLengthError);
    }
}