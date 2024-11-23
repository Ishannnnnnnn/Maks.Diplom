namespace Application.Dto.InstrumentStoreDto;

/// <summary>
/// Дто запроса на обновление InstrumentStore
/// </summary>
public class UpdateInstrumentStoreRequest : BaseInstrumentStoreDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
}