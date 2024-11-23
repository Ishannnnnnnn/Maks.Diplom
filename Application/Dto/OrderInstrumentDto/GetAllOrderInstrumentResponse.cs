namespace Application.Dto.OrderInstrumentDto;

/// <summary>
/// Дто ответа на получение всех OrderInstrument
/// </summary>
public class GetAllOrderInstrumentResponse : BaseOrderInstrumentDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
}