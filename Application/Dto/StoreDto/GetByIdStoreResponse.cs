namespace Application.Dto.StoreDto;

/// <summary>
/// Дто ответа на получение всех Store по идентификатору
/// </summary>
public class GetByIdStoreResponse : BaseStoreDto
{
    public Guid Id { get; init; }
}