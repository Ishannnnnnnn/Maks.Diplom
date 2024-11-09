using Domain.Entities;

namespace Application.Interfaces;

/// <summary>
/// Репозиторий сущности User
/// </summary>
public interface IUserRepository : IRepository<User>
{
    /// <summary>
    /// Обновление
    /// </summary>
    /// <param name="user">Пользователь на обновление.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный пользователь.</returns>
    public Task<User> UpdateAsync(User user, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление
    /// </summary>
    /// <param name="user">Пользователь на удаление.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public Task DeleteAsync(User user, CancellationToken cancellationToken);
    
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