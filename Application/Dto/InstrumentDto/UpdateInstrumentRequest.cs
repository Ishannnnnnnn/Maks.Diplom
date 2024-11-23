namespace Application.Dto.InstrumentDto;

/// <summary>
/// Дто запроса на обновление Instrument
/// </summary>
public class UpdateInstrumentRequest : BaseInstrumentDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
}