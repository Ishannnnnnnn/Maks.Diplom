using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Dto.UserDto;
using Application.Dto.UserDto.Auth;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services;

/// <summary>
/// Сервис сущности User
/// </summary>
public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly GoogleCloudService _googleCloudService;
    private readonly IMapper _mapper;
    private readonly string _secretKey;

    public UserService(
        IUserRepository userRepository,
        IMapper mapper,
        string secretKey,
        GoogleCloudService googleCloudService)
    {
        _userRepository = userRepository;
        _googleCloudService = googleCloudService;
        _mapper = mapper;
        _secretKey = secretKey;
    }

    /// <summary>
    /// Создание User
    /// </summary>
    /// <param name="userRequest">User на создание.</param>
    /// <param name="fileStream">Стрим файла.</param>
    /// <param name="fileName">Название файла.</param>
    /// <param name="contentType">Тип файла.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Созданный User.</returns>
    public async Task<AddUserResponse> AddAsync(
        AddUserRequest userRequest,
        Stream fileStream,
        string fileName,
        string contentType,
        CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(userRequest);
        if (await _userRepository.IsUniqueUser(user.Email, cancellationToken))
            return null;
        
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        user.AvatarUrl = await _googleCloudService.UploadFileAsync(fileStream, fileName, contentType);
        
        var createdUser = await _userRepository.AddAsync(user, cancellationToken);
        await _userRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<AddUserResponse>(createdUser);
    }

    /// <summary>
    /// Логин
    /// </summary>
    /// <param name="loginRequest">Данные для входа в аккаунт.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Токен JWT.</returns>
    public async Task<LoginUserResponse> LoginAsync(LoginUserRequest loginRequest, CancellationToken cancellationToken)
    {
        var user = await _userRepository.IsUserExistAsync(loginRequest.Email, cancellationToken);
        if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
            return null;
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            }),
            Expires = DateTime.Now.AddHours(24),
            SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        LoginUserResponse loginResponse = new LoginUserResponse
        {
            Email = user.Email,
            Password = user.Password,
            Token = tokenHandler.WriteToken(token)
        };

        return loginResponse;
    }

    /// <summary>
    /// Удаление User
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await GetByIdOrThrowAsync(id, cancellationToken);
        
        var oldFileUrl = user.AvatarUrl;
        var uri = new Uri(oldFileUrl);
        await _googleCloudService.DeleteFileAsync(Path.GetFileName(uri.AbsolutePath));
        
        await _userRepository.DeleteAsync(user, cancellationToken); 
        await _userRepository.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Обновление User
    /// </summary>
    /// <param name="userRequest">User на обновление.</param>
    /// <param name="fileStream">Стрим файла.</param>
    /// <param name="fileName">Название файла.</param>
    /// <param name="contentType">Тип файла.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный User.</returns>
    public async Task<UpdateUserResponse> UpdateAsync(
        UpdateUserRequest userRequest,
        Stream fileStream,
        string fileName,
        string contentType,
        CancellationToken cancellationToken)
    {
        var user = await GetByIdOrThrowAsync(userRequest.Id, cancellationToken);
        
        var oldFileUrl = user.AvatarUrl;
        var uri = new Uri(oldFileUrl);
        await _googleCloudService.DeleteFileAsync(Path.GetFileName(uri.AbsolutePath));
        
        var newAvatarUrl = await _googleCloudService.UploadFileAsync(fileStream, fileName, contentType);

        user.Update(
            new FullName(
                userRequest.FullName.Name, 
                userRequest.FullName.Surname, 
                userRequest.FullName.Patronymic),
            userRequest.Nickname,
            userRequest.Email,
            BCrypt.Net.BCrypt.HashPassword(userRequest.Password),
            userRequest.Role,
            userRequest.Balance,
            userRequest.Purchases,
            userRequest.MoneySpend,
            newAvatarUrl);
        
        await _userRepository.UpdateAsync(user, cancellationToken);
        await _userRepository.SaveChangesAsync(cancellationToken);
        
        return _mapper.Map<UpdateUserResponse>(user);
    }

    /// <summary>
    /// Получение User по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>User.</returns>
    public async Task<GetByIdUserResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await GetByIdOrThrowAsync(id, cancellationToken);
        return _mapper.Map<GetByIdUserResponse>(user);
    }

    /// <summary>
    /// Получение всех User
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список всех User.</returns>
    public async Task<List<GetAllUserResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<GetAllUserResponse>>(users);
    }
    
    /// <summary>
    /// Декодирование токена
    /// </summary>
    /// <param name="token">JWT токен.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Пользователь.</returns>
    public async Task<User> DecodeJwtToken(string token, CancellationToken cancellationToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);
        
        var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "nameid")?.Value;
        return await _userRepository.GetByIdAsync(Guid.Parse(userIdClaim), cancellationToken);
    }

    /// <summary>
    /// Метод проверки на наличие объекта
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>User.</returns>
    private async Task<User> GetByIdOrThrowAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);
        if (user != null)
            return user;
        
        return null;
    }
}