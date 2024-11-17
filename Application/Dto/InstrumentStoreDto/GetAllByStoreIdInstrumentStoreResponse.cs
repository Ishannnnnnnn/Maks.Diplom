namespace Application.Dto.InstrumentStoreDto;

/// <summary>
/// Дто ответа на получение всех InstrumentStore по идентификатору магазина
/// </summary>
public class GetAllByStoreIdInstrumentStoreResponse : BaseInstrumentStoreDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
}