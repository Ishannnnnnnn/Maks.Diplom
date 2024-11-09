using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Dal;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

/// <summary>
/// Репозиторий для сущности Store
/// </summary>
public class StoreRepository : IStoreRepository
{
    private readonly MusicStoreDbContext _dbContext;
    
    public StoreRepository(MusicStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    /// <summary>
    /// Добавление Store
    /// </summary>
    /// <param name="store">Store.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Store.</returns>
    public async Task<Store> AddAsync(Store store, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(store, cancellationToken);
        return store;
    }
    
    /// <summary>
    /// Обновление
    /// </summary>
    /// <param name="store">Данные для обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный Store.</returns>
    public Task<Store> UpdateAsync(Store store, CancellationToken cancellationToken)
    {
        _dbContext.Stores.Update(store);
        return Task.FromResult(store);
    }
    
    /// <summary>
    /// Удаление
    /// </summary>
    /// <param name="store">Store.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public Task DeleteAsync(Store store, CancellationToken cancellationToken)
    {
        _dbContext.Stores.Remove(store);
        return Task.CompletedTask;
    }
    
    /// <summary>
    /// Получение по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Store.</returns>
    public async Task<Store?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Stores.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    /// <summary>
    /// Получение всех
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список Store.</returns>
    public async Task<List<Store>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Stores.ToListAsync(cancellationToken);
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