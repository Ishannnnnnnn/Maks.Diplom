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
/// Репозиторий для сущности OrderInstrument
/// </summary>
public class OrderInstrumentRepository : IOrderInstrumentRepository
{
    private readonly MusicStoreDbContext _dbContext;
    
    public OrderInstrumentRepository(MusicStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    /// <summary>
    /// Добавление OrderInstrument
    /// </summary>
    /// <param name="orderInstrument">OrderInstrument.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>OrderInstrument.</returns>
    public async Task<OrderInstrument> AddAsync(OrderInstrument orderInstrument, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(orderInstrument, cancellationToken);
        return orderInstrument;
    }
    
    /// <summary>
    /// Получение по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>OrderInstrument.</returns>
    public async Task<OrderInstrument?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.OrderInstruments.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    /// <summary>
    /// Получение всех
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список OrderInstrument.</returns>
    public async Task<List<OrderInstrument>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.OrderInstruments.ToListAsync(cancellationToken);
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