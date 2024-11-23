namespace Application.Dto.StoreDto;

/// <summary>
/// Дто ответа на получение всех Store
/// </summary>
public class GetAllStoreResponse : BaseStoreDto
{
    public Guid Id { get; init; }
}