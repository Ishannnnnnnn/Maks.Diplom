using Domain.Entities;

namespace Application.Dto.OrderDto;

/// <summary>
/// Дто ответа на получение всех Order по идентификатору пользователя
/// </summary>
public class GetAllByUserIdResponse : BaseOrderDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Инструменты заказа
    /// </summary>
    public List<OrderInstrument> OrderInstruments { get; init; }
}