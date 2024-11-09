using Domain.Entities;

namespace Application.Dto.OrderDto;

/// <summary>
/// Базовое дто Order
/// </summary>
public class BaseOrderDto
{
    /// <summary>
    /// Дата заказа
    /// </summary>
    public DateTime OrderDate { get; init; }
    
    /// <summary>
    /// Идентификатор магазина
    /// </summary>
    public Guid StoreId { get; init; }
    
    /// <summary>
    /// Магазин
    /// </summary>
    public Store Store { get; init; }
    
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; init; }
    
    /// <summary>
    /// Пользователь
    /// </summary>
    public User User { get; init; }
}