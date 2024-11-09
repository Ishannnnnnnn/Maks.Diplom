namespace Application.Dto.UserDto;

/// <summary>
/// Дто запроса на обновление User
/// </summary>
public class UpdateUserRequest : BaseUserDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
}