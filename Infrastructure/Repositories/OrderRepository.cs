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
/// Репозиторий для сущности Order
/// </summary>
public class OrderRepository : IOrderRepository
{
    private readonly MusicStoreDbContext _dbContext;
    
    public OrderRepository(MusicStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    /// <summary>
    /// Добавление заказа
    /// </summary>
    /// <param name="order">Заказ.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Заказ.</returns>
    public async Task<Order> AddAsync(Order order, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(order, cancellationToken);
        return order;
    }
    
    /// <summary>
    /// Получение по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Заказ.</returns>
    public async Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Orders
            .Include(o => o.Store)
            .Include(o => o.OrderInstruments)
            .ThenInclude(oi => oi.Instrument)
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    /// <summary>
    /// Получение всех заказов пользователя
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список заказов пользователя.</returns>
    public async Task<List<Order>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _dbContext.Orders
            .Include(o => o.Store) 
            .Include(o => o.OrderInstruments)
            .ThenInclude(oi => oi.Instrument)
            .Where(o => o.UserId == userId)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Получение всех
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список заказов.</returns>
    public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Orders.ToListAsync(cancellationToken);
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