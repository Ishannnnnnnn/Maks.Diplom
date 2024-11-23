namespace Application.Dto.InstrumentDto;

/// <summary>
/// Дто ответа на обновление Instrument
/// </summary>
public class UpdateInstrumentResponse : BaseInstrumentDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
}