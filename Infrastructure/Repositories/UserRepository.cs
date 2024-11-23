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
/// Репозиторий для сущности User
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly MusicStoreDbContext _dbContext;
    
    public UserRepository(MusicStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Проверка уникальности пользователя
    /// </summary>
    /// <param name="email">Электронная почта.</param>
    /// <param name="cancellationToken">Токен отмены</param>
    public async Task<bool> IsUniqueUser(string email, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        if (user == null)
            return false;

        return true;
    }

    /// <summary>
    /// Проверка существования пользователя
    /// </summary>
    /// <param name="email">Электронная почта.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Пользователь.</returns> 
    public async Task<User> IsUserExistAsync(string email, CancellationToken cancellationToken)
    {
        var existUser = await _dbContext.Users.FirstOrDefaultAsync(
            u => u.Email == email, cancellationToken);

        if (existUser == null)
            return null;

        return existUser;
    }

    /// <summary>
    /// Добавление пользователя
    /// </summary>
    /// <param name="user">Пользователь.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Пользователь.</returns>
    public async Task<User> AddAsync(User user, CancellationToken cancellationToken)
    {
        await _dbContext.AddAsync(user, cancellationToken);
        return user;
    }
    
    /// <summary>
    /// Обновление
    /// </summary>
    /// <param name="user">Данные для обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный пользователь.</returns>
    public Task<User> UpdateAsync(User user, CancellationToken cancellationToken)
    {
        _dbContext.Users.Update(user);
        return Task.FromResult(user);
    }
    
    /// <summary>
    /// Удаление
    /// </summary>
    /// <param name="entity">Пользователь.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public Task DeleteAsync(User entity, CancellationToken cancellationToken)
    {
        _dbContext.Users.Remove(entity);
        return Task.CompletedTask;
    }
    
    /// <summary>
    /// Получение по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Пользователь.</returns>
    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }

    /// <summary>
    /// Получение всех
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список пользователей.</returns>
    public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Users.ToListAsync(cancellationToken);
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