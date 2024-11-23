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
/// Репозиторий для сущности Instrument
/// </summary>
public class InstrumentRepository : IInstrumentRepository
{
    private readonly MusicStoreDbContext _dbContext;
    
    public InstrumentRepository(MusicStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    /// <summary>
    /// Добавление инструмента
    /// </summary>
    /// <param name="instrument">Инструмент.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Инструмент.</returns>
    public async Task<Instrument> AddAsync(Instrument instrument, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(instrument, cancellationToken);
        return instrument;
    }
    
    /// <summary>
    /// Обновление
    /// </summary>
    /// <param name="instrument">Данные для обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный инструмент.</returns>
    public Task<Instrument> UpdateAsync(Instrument instrument, CancellationToken cancellationToken)
    {
        _dbContext.Instruments.Update(instrument);
        return Task.FromResult(instrument);
    }
    
    /// <summary>
    /// Удаление
    /// </summary>
    /// <param name="instrument">Инструмент.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public Task DeleteAsync(Instrument instrument, CancellationToken cancellationToken)
    {
        _dbContext.Instruments.Remove(instrument);
        return Task.CompletedTask;
    }
    
    /// <summary>
    /// Получение по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Инструмент.</returns>
    public async Task<Instrument?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Instruments.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    /// <summary>
    /// Получение всех
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список инструментов.</returns>
    public async Task<List<Instrument>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Instruments.ToListAsync(cancellationToken);
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