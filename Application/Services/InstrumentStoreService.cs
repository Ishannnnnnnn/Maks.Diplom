using Application.Dto.InstrumentStoreDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

/// <summary>
/// Сервис сущности InstrumentStore
/// </summary>
public class InstrumentStoreService
{
    private readonly IInstrumentStoreRepository _instrumentStoreRepository;
    private readonly IMapper _mapper;

    public InstrumentStoreService(
        IInstrumentStoreRepository instrumentStoreRepository,
        IMapper mapper)
    {
        _instrumentStoreRepository = instrumentStoreRepository;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Создание InstrumentStore
    /// </summary>
    /// <param name="instrumentStoreRequest">InstrumentStore на создание.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Созданный InstrumentStore.</returns>
    public async Task<AddInstrumentStoreResponse> AddAsync(
        AddInstrumentStoreRequest instrumentStoreRequest,
        CancellationToken cancellationToken)
    {
        var instrumentStore = _mapper.Map<InstrumentStore>(instrumentStoreRequest);
        var createdInstrumentStore = await _instrumentStoreRepository.AddAsync(instrumentStore, cancellationToken);
        await _instrumentStoreRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<AddInstrumentStoreResponse>(createdInstrumentStore);
    }
    
    /// <summary>
    /// Обновление кол-ва инструментов в магазине
    /// </summary>
    /// <param name="instrumentStoreId">Идентификатор InstrumentStore.</param>
    /// <param name="updateValue">Значение изменения.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task UpdateInstrumentAmountAsync(
        Guid instrumentStoreId,
        int updateValue,
        CancellationToken cancellationToken)
    {
        var instrumentStore = await _instrumentStoreRepository.GetByIdAsync(instrumentStoreId, cancellationToken);
        instrumentStore.UpdateInstrumentAmount(updateValue);
        await _instrumentStoreRepository.UpdateAsync(instrumentStore, cancellationToken);
        await _instrumentStoreRepository.SaveChangesAsync(cancellationToken);
    }
    
    /// <summary>
    /// Удаление InstrumentStore
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var instrumentStore = await GetByIdOrThrowAsync(id, cancellationToken);
        
        await _instrumentStoreRepository.DeleteAsync(instrumentStore, cancellationToken); 
        await _instrumentStoreRepository.SaveChangesAsync(cancellationToken);
    }
    
    /// <summary>
    /// Получение InstrumentStore по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>InstrumentStore.</returns>
    public async Task<GetByIdInstrumentStoreResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var instrumentStore = await GetByIdOrThrowAsync(id, cancellationToken);
        return _mapper.Map<GetByIdInstrumentStoreResponse>(instrumentStore);
    }

    /// <summary>
    /// Получение всех InstrumentStore
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список всех InstrumentStore.</returns>
    public async Task<List<GetAllInstrumentStoreResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var instrumentStores = await _instrumentStoreRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<GetAllInstrumentStoreResponse>>(instrumentStores);
    }

    /// <summary>
    /// Получение всех InstrumentStore по идентификатору магазина
    /// </summary>
    /// <param name="storeId">Идентификатор магазина.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список InstrumentStore.</returns>
    public async Task<List<GetAllByStoreIdInstrumentStoreResponse>> GetAllByStoreIdAsync(Guid storeId, CancellationToken cancellationToken)
    {
        var instrumentStores = await _instrumentStoreRepository.GetAllByStoreIdAsync(storeId, cancellationToken);
        return _mapper.Map<List<GetAllByStoreIdInstrumentStoreResponse>>(instrumentStores);
    }
    
    /// <summary>
    /// Метод проверки на наличие объекта
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>InstrumentStore.</returns>
    private async Task<InstrumentStore> GetByIdOrThrowAsync(Guid id, CancellationToken cancellationToken)
    {
        var instrumentStore = await _instrumentStoreRepository.GetByIdAsync(id, cancellationToken);
        if (instrumentStore != null)
            return instrumentStore;
        
        return null;
    }
}