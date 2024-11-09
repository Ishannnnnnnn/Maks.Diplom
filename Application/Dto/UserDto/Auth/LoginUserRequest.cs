namespace Application.Dto.UserDto.Auth;

public class LoginUserRequest
{
    public string Email { get; init; }
    public string Password { get; init; }
}