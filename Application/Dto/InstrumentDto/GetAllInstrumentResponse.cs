namespace Application.Dto.InstrumentDto;

/// <summary>
/// Дто ответа на получение всех Instrument
/// </summary>
public class GetAllInstrumentResponse : BaseInstrumentDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
}