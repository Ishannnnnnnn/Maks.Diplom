using Application.Dto.OrderDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

/// <summary>
/// Сервис сущности Order
/// </summary>
public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(
        IOrderRepository orderRepository,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Создание Order
    /// </summary>
    /// <param name="orderRequest">Order на создание.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Созданный Order.</returns>
    public async Task<AddOrderResponse> AddAsync(
        AddOrderRequest orderRequest,
        CancellationToken cancellationToken)
    {
        var order = _mapper.Map<Order>(orderRequest);
        var createdOrder = await _orderRepository.AddAsync(order, cancellationToken);
        await _orderRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<AddOrderResponse>(createdOrder);
    }
    
    /// <summary>
    /// Получение Order по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Order.</returns>
    public async Task<GetByIdOrderResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var order = await GetByIdOrThrowAsync(id, cancellationToken);
        return _mapper.Map<GetByIdOrderResponse>(order);
    }
    
    /// <summary>
    /// Получение всех Order по идентификатору пользователя
    /// </summary>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список Order.</returns>
    public async Task<List<GetAllByUserIdResponse>> GetAllByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetAllByUserIdAsync(userId, cancellationToken);
        return _mapper.Map<List<GetAllByUserIdResponse>>(orders);
    }

    /// <summary>
    /// Получение всех Order
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список всех Order.</returns>
    public async Task<List<GetAllOrderResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<GetAllOrderResponse>>(orders);
    }
    
    /// <summary>
    /// Метод проверки на наличие объекта
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Order.</returns>
    private async Task<Order> GetByIdOrThrowAsync(Guid id, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(id, cancellationToken);
        if (order != null)
            return order;
        
        return null;
    }
}