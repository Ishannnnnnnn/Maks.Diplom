using Application.Dto.OrderInstrumentDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

/// <summary>
/// Сервис сущности OrderInstrument
/// </summary>
public class OrderInstrumentService
{
    private readonly IOrderInstrumentRepository _orderInstrumentRepository;
    private readonly IMapper _mapper;

    public OrderInstrumentService(
        IOrderInstrumentRepository orderInstrumentRepository,
        IMapper mapper)
    {
        _orderInstrumentRepository = orderInstrumentRepository;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Создание OrderInstrument
    /// </summary>
    /// <param name="orderInstrumentRequest">OrderInstrument на создание.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Созданный OrderInstrument.</returns>
    public async Task<AddOrderInstrumentResponse> AddAsync(
        AddOrderInstrumentRequest orderInstrumentRequest,
        CancellationToken cancellationToken)
    {
        var orderInstrument = _mapper.Map<OrderInstrument>(orderInstrumentRequest);
        var createdOrderInstrument = await _orderInstrumentRepository.AddAsync(orderInstrument, cancellationToken);
        await _orderInstrumentRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<AddOrderInstrumentResponse>(createdOrderInstrument);
    }
    
    /// <summary>
    /// Получение OrderInstrument по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>OrderInstrument.</returns>
    public async Task<GetByIdOrderInstrumentResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var orderInstrument = await GetByIdOrThrowAsync(id, cancellationToken);
        return _mapper.Map<GetByIdOrderInstrumentResponse>(orderInstrument);
    }

    /// <summary>
    /// Получение всех OrderInstrument
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список всех OrderInstrument.</returns>
    public async Task<List<GetAllOrderInstrumentResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var orderInstruments = await _orderInstrumentRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<GetAllOrderInstrumentResponse>>(orderInstruments);
    }
    
    /// <summary>
    /// Метод проверки на наличие объекта
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>OrderInstrument.</returns>
    private async Task<OrderInstrument> GetByIdOrThrowAsync(Guid id, CancellationToken cancellationToken)
    {
        var orderInstrument = await _orderInstrumentRepository.GetByIdAsync(id, cancellationToken);
        if (orderInstrument != null)
            return orderInstrument;
        
        return null;
    }
}