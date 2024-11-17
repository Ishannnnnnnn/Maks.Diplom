using Domain.Entities;

namespace Application.Interfaces;

/// <summary>
/// Репозиторий сущности InstrumentStore
/// </summary>
public interface IInstrumentStoreRepository : IRepository<InstrumentStore>
{
    /// <summary>
    /// Удаление
    /// </summary>
    /// <param name="instrumentStore">InstrumentStore на удаление.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public Task DeleteAsync(InstrumentStore instrumentStore, CancellationToken cancellationToken);
    
    /// <summary>
    /// Обновление
    /// </summary>
    /// <param name="instrumentStore">InstrumentStore на обновление.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный InstrumentStore.</returns>
    public Task<InstrumentStore> UpdateAsync(InstrumentStore instrumentStore, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех InstrumentStore для конкретного магазина
    /// </summary>
    /// <param name="storeId">Идентификатор магазина.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список InstrumentStore.</returns>
    public Task<List<InstrumentStore>> GetAllByStoreIdAsync(Guid storeId, CancellationToken cancellationToken);
}