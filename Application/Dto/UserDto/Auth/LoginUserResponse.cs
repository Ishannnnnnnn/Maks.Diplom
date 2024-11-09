namespace Application.Dto.UserDto.Auth;

public class LoginUserResponse
{
    public string Email { get; init; }
    public string Password { get; init; }
    public string Token { get; init; }
}