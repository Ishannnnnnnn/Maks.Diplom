namespace Application.Dto.StoreDto;

/// <summary>
/// Дто ответа на обновление Store
/// </summary>
public class UpdateStoreResponse : BaseStoreDto
{
    public Guid Id { get; init; }
}