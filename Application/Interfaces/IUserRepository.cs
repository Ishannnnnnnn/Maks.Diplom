using Domain.Entities;

namespace Application.Interfaces;

/// <summary>
/// Репозиторий сущности User
/// </summary>
public interface IUserRepository : IRepository<User>
{
    /// <summary>
    /// Проверка уникальности пользователя
    /// </summary>
    /// <param name="email">Электронная почта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public Task<bool> IsUniqueUser(string email, CancellationToken cancellationToken);

    /// <summary>
    /// Проверка существования пользователя
    /// </summary>
    /// <param name="email">Электронная почта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Пользователь.</returns>
    public Task<User> IsUserExistAsync(string email, CancellationToken cancellationToken);
}