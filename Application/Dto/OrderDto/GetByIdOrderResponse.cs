using Domain.Entities;

namespace Application.Dto.OrderDto;

/// <summary>
/// Дто ответа на получение Order по идентификатору
/// </summary>
public class GetByIdOrderResponse : BaseOrderDto
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