using Domain.Entities;

namespace Application.Interfaces;

/// <summary>
/// Репозиторий сущности Instrument
/// </summary>
public interface IInstrumentRepository : IRepository<Instrument>
{
    /// <summary>
    /// Обновление
    /// </summary>
    /// <param name="instrument">Инструмент на обновление.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный инструмент.</returns>
    public Task<Instrument> UpdateAsync(Instrument instrument, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление
    /// </summary>
    /// <param name="instrument">Инструмент на удаление.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public Task DeleteAsync(Instrument instrument, CancellationToken cancellationToken);
}