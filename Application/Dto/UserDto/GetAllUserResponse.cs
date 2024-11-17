namespace Application.Dto.UserDto;

/// <summary>
/// Дто ответа на получение всех User
/// </summary>
public class GetAllUserResponse : BaseUserDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
}