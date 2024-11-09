namespace Application.Dto.StoreDto;

/// <summary>
/// Дто запроса на обновление Store
/// </summary>
public class UpdateStoreRequest : BaseStoreDto
{
    public Guid Id { get; init; }
}