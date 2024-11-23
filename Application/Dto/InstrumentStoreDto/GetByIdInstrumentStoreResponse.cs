namespace Application.Dto.InstrumentStoreDto;

/// <summary>
/// Дто ответа на получение InstrumentStore по идентификатору
/// </summary>
public class GetByIdInstrumentStoreResponse : BaseInstrumentStoreDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
}