using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Dal;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

/// <summary>
/// Репозиторий для сущности InstrumentStore
/// </summary>
public class InstrumentStoreRepository : IInstrumentStoreRepository
{
    private readonly MusicStoreDbContext _dbContext;
    
    public InstrumentStoreRepository(MusicStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    /// <summary>
    /// Добавление InstrumentStore
    /// </summary>
    /// <param name="instrumentStore">InstrumentStore.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>InstrumentStore.</returns>
    public async Task<InstrumentStore> AddAsync(InstrumentStore instrumentStore, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(instrumentStore, cancellationToken);
        return instrumentStore;
    }
    
    /// <summary>
    /// Обновление
    /// </summary>
    /// <param name="instrumentStore">Данные для обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный InstrumentStore.</returns>
    public Task<InstrumentStore> UpdateAsync(InstrumentStore instrumentStore, CancellationToken cancellationToken)
    {
        _dbContext.InstrumentStores.Update(instrumentStore);
        return Task.FromResult(instrumentStore);
    }
    
    /// <summary>
    /// Удаление
    /// </summary>
    /// <param name="instrumentStore">InstrumentStore.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public Task DeleteAsync(InstrumentStore instrumentStore, CancellationToken cancellationToken)
    {
        _dbContext.InstrumentStores.Remove(instrumentStore);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Получение по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>InstrumentStore.</returns>
    public async Task<InstrumentStore?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.InstrumentStores.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    /// <summary>
    /// Получение всех
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список InstrumentStore.</returns>
    public async Task<List<InstrumentStore>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.InstrumentStores.ToListAsync(cancellationToken);
    }
    
    /// <summary>
    /// Получение всех InstrumentStore для конкретного магазина
    /// </summary>
    /// <param name="storeId">Идентификатор магазина.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список InstrumentStore.</returns>
    public async Task<List<InstrumentStore>> GetAllByStoreIdAsync(Guid storeId, CancellationToken cancellationToken)
    {
        return await _dbContext.InstrumentStores
            .Where(i => i.StoreId == storeId)
            .Include(i => i.Instrument)
            .ToListAsync(cancellationToken);
    }
    
    /// <summary>
    /// Сохранение изменений в базе
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        _dbContext.SaveChangesAsync(cancellationToken);
        return Task.CompletedTask;
    }
}