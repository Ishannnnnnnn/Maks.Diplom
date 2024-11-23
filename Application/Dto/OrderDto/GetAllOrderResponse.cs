namespace Application.Dto.OrderDto;

/// <summary>
/// Дто ответа на получение всех Order
/// </summary>
public class GetAllOrderResponse : BaseOrderDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
}