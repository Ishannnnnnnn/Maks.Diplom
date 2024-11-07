using Domain.Validations.Validators.ValueObjects;
using FluentValidation;

namespace Domain.ValueObjects;

/// <summary>
/// Полное имя
/// </summary>
public abstract class FullName
{
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; private set; }
    
    /// <summary>
    /// Отчество
    /// </summary>
    public string Patronymic { get; private set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name">Имя.</param>
    /// <param name="surname">Фамилия.</param>
    /// <param name="patronymic">Отчество.</param>
    protected FullName(
        string name,
        string surname,
        string patronymic)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        
        Validate();
    }
    
    private void Validate()
    {
        var validator = new FullNameValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(" || ", result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
}