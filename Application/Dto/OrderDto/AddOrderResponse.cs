namespace Application.Dto.OrderDto;

/// <summary>
/// Дто ответа на добавление Order
/// </summary>
public class AddOrderResponse : BaseOrderDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
}