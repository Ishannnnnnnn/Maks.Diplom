using Application.Dto.ValueObjects;
using Domain.Primitives;

namespace Application.Dto.UserDto;

/// <summary>
/// Базовое дто User
/// </summary>
public class BaseUserDto
{
    /// <summary>
    /// Полное имя
    /// </summary>
    public FullNameDto FullName { get; init; }
    
    /// <summary>
    /// Почта
    /// </summary>
    public string Nickname { get; init; }
    
    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; init; }
    
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; init; }
    
    /// <summary>
    /// Роль
    /// </summary>
    public Role Role { get; init; }
    
    /// <summary>
    /// Баланс пользователя
    /// </summary>
    public decimal Balance { get; init; }
    
    /// <summary>
    /// Кол-во покупок всего
    /// </summary>
    public int Purchases { get; init; }
    
    /// <summary>
    /// Кол-во потраченных денег всего
    /// </summary>
    public decimal MoneySpend { get; init; }
}