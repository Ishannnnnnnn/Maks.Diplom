namespace Application.Dto.User;

/// <summary>
/// Дто ответа на получение User по идентификатору
/// </summary>
public class GetByIdUserResponse : BaseUserDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; init; }
}