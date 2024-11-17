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
    /// Никнейм пользователя
    /// </summary>
    public string Nickname { get; set; }
    
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
    /// Дата регистрации
    /// </summary>
    public DateTime RegistrationDate { get; set; }
    
    /// <summary>
    /// Аватар
    /// </summary>
    public string AvatarUrl { get; set; }
    
    /// <summary>
    /// Баланс пользователя
    /// </summary>
    public decimal Balance { get; set; }
    
    /// <summary>
    /// Кол-во покупок всего
    /// </summary>
    public int Purchases { get; set; }
    
    /// <summary>
    /// Кол-во потраченных денег всего
    /// </summary>
    public decimal MoneySpend { get; set; }
    
    /// <summary>
    /// Список заказов
    /// </summary>
    public ICollection<Order> Orders { get; set; } = new List<Order>();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="fullName">Полное имя.</param>
    /// <param name="nickname">Никнейм.</param>
    /// <param name="email">Почта.</param>
    /// <param name="password">Пароль.</param>
    /// <param name="role">Роль.</param>
    /// <param name="balance">Баланс.</param>
    /// <param name="purchases">Кол-во покупок в приложении.</param>
    /// <param name="moneySpend">Кол-во потраченных денег.</param>
    public User(
        Guid id,
        FullName fullName,
        string nickname,
        string email,
        string password,
        Role role,
        decimal balance,
        int purchases,
        decimal moneySpend)
    {
        SetId(id);
        FullName = fullName;
        Nickname = nickname;
        Email = email;
        Password = password;
        Role = role;
        Balance = balance;
        Purchases = purchases;
        MoneySpend = moneySpend;
        
        Validate();
    }

    /// <summary>
    /// Обновление
    /// </summary>
    /// <param name="fullName">Полное имя.</param>
    /// <param name="nickname">Никнейм.</param>
    /// <param name="email">Почта.</param>
    /// <param name="password">Пароль.</param>
    /// <param name="role">Роль.</param>
    /// <param name="balance">Баланс.</param>
    /// <param name="purchases">Кол-во покупок в приложении.</param>
    /// <param name="moneySpend">Кол-во потраченных денег.</param>
    /// <param name="newAvatarUrl">Новый аватар.</param>
    /// <returns>Обновленный User.</returns>
    public User Update(
        FullName fullName,
        string nickname,
        string email,
        string password,
        Role role,
        decimal balance,
        int purchases,
        decimal moneySpend,
        string newAvatarUrl)
    {
        FullName = fullName;
        Nickname = nickname;
        Email = email;
        Password = password;
        Role = role;
        Balance = balance;
        Purchases = purchases;
        MoneySpend = moneySpend;
        AvatarUrl = newAvatarUrl;
        
        Validate();
        
        return this;
    }

    /// <summary>
    /// Обновление баланса пользователя
    /// </summary>
    /// <param name="updateValueBalance">Значение изменения баланса.</param>
    /// <param name="updateValueMoneySpend">Значение изменения потраченных денег.</param>
    /// <param name="updateValuePurchases">Значение изменения кол-во покупок.</param>
    /// <returns>Пользователь с новым балансом.</returns>
    public User UpdateValues(
        decimal updateValueBalance,
        decimal updateValueMoneySpend,
        int updateValuePurchases)
    {
        Balance += updateValueBalance;
        MoneySpend = updateValueMoneySpend;
        Purchases = updateValuePurchases;
        
        Validate();

        return this;
    }

    public void Validate()
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