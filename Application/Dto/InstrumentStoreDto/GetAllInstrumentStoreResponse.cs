namespace Application.Dto.InstrumentStoreDto;

/// <summary>
/// Дто ответа на получение всех InstrumentStore
/// </summary>
public class GetAllInstrumentStoreResponse : BaseInstrumentStoreDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
}