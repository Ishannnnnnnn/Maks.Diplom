namespace Application.Dto.InstrumentDto;

/// <summary>
/// Дто ответа на получение Instrument по идентификатору
/// </summary>
public class GetByIdInstrumentResponse : BaseInstrumentDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
}