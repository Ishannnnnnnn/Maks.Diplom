namespace Application.Dto.InstrumentStoreDto;

/// <summary>
/// Дто ответа на обновление InstrumentStore
/// </summary>
public class UpdateInstrumentStoreResponse : BaseInstrumentStoreDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
}