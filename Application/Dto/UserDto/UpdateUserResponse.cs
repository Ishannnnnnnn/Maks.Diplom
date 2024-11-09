namespace Application.Dto.UserDto;

/// <summary>
/// Дто ответа на обновление User
/// </summary>
public class UpdateUserResponse : BaseUserDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
}