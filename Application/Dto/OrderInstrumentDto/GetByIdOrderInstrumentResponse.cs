namespace Application.Dto.OrderInstrumentDto;

/// <summary>
/// Дто ответа на получение OrderInstrument по идентификатору
/// </summary>
public class GetByIdOrderInstrumentResponse : BaseOrderInstrumentDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
}