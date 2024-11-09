using Application.Dto.StoreDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Services;

/// <summary>
/// Сервис сущности Store
/// </summary>
public class StoreService
{
    private readonly IStoreRepository _storeRepository;
    private readonly IMapper _mapper;

    public StoreService(
        IStoreRepository storeRepository,
        IMapper mapper)
    {
        _storeRepository = storeRepository;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Создание Store
    /// </summary>
    /// <param name="storeRequest">Store на создание.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Созданный Store.</returns>
    public async Task<AddStoreResponse> AddAsync(
        AddStoreRequest storeRequest,
        CancellationToken cancellationToken)
    {
        var store = _mapper.Map<Store>(storeRequest);
        
        var createdStore = await _storeRepository.AddAsync(store, cancellationToken);
        await _storeRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<AddStoreResponse>(createdStore);
    }

    /// <summary>
    /// Удаление Store
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var store = await GetByIdOrThrowAsync(id, cancellationToken);
        
        await _storeRepository.DeleteAsync(store, cancellationToken); 
        await _storeRepository.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Обновление Store
    /// </summary>
    /// <param name="storeRequest">Store на обновление.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный Store.</returns>
    public async Task<UpdateStoreResponse> UpdateAsync(
        UpdateStoreRequest storeRequest,
        CancellationToken cancellationToken)
    {
        var store = await GetByIdOrThrowAsync(storeRequest.Id, cancellationToken);

        store.Update(
            new Address(
                storeRequest.Address.City, 
                storeRequest.Address.Street, 
                storeRequest.Address.HouseNumber),
            storeRequest.Phone);
        
        await _storeRepository.UpdateAsync(store, cancellationToken);
        await _storeRepository.SaveChangesAsync(cancellationToken);
        
        return _mapper.Map<UpdateStoreResponse>(store);
    }

    /// <summary>
    /// Получение Store по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Store.</returns>
    public async Task<GetByIdStoreResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var store = await GetByIdOrThrowAsync(id, cancellationToken);
        return _mapper.Map<GetByIdStoreResponse>(store);
    }

    /// <summary>
    /// Получение всех Store
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список всех Store.</returns>
    public async Task<List<GetAllStoreResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var stores = await _storeRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<GetAllStoreResponse>>(stores);
    }

    /// <summary>
    /// Метод проверки на наличие объекта
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Store.</returns>
    private async Task<Store> GetByIdOrThrowAsync(Guid id, CancellationToken cancellationToken)
    {
        var store = await _storeRepository.GetByIdAsync(id, cancellationToken);
        if (store != null)
            return store;
        
        return null;
    }
}