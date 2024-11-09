using Domain.Entities;

namespace Application.Interfaces;

/// <summary>
/// Репозиторий сущности Store
/// </summary>
public interface IStoreRepository : IRepository<Store>
{
    /// <summary>
    /// Обновление
    /// </summary>
    /// <param name="store">Store на обновление.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный Store.</returns>
    public Task<Store> UpdateAsync(Store store, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление
    /// </summary>
    /// <param name="store">Store на удаление.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public Task DeleteAsync(Store store, CancellationToken cancellationToken);
}