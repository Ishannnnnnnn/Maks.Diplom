using Domain.Primitives;
using Domain.Validations.Validators.Entities;
using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Entities;

/// <summary>
/// Сущность пользователя
/// </summary>
public class User : BaseEntity
{
    /// <summary>
    /// Полное имя
    /// </summary>
    public FullName FullName { get; set; }
    
    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// Роль
    /// </summary>
    public Role Role { get; set; }
    
    /// <summary>
    /// Список заказов
    /// </summary>
    public ICollection<Order> Orders { get; set; } = new List<Order>();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="fullName">Полное имя.</param>
    /// <param name="email">Почта.</param>
    /// <param name="password">Пароль.</param>
    /// <param name="role">Роль.</param>
    public User(
        Guid id,
        FullName fullName,
        string email,
        string password,
        Role role)
    {
        SetId(id);
        FullName = fullName;
        Email = email;
        Password = password;
        Role = role;
        
        Validate();
    }
    
    private void Validate()
    {
        var validator = new UserValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(" || ", result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
    
    public User()
    {
    }
}