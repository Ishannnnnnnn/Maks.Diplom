using Domain.Entities;

namespace Application.Interfaces;

/// <summary>
/// Репозиторий сущности Order
/// </summary>
public interface IOrderRepository : IRepository<Order>
{
    /// <summary>
    /// Получение всех заказов пользователя
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список заказов пользователя.</returns>
    public Task<List<Order>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken);
}