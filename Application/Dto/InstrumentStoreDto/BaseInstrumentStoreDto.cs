using Domain.Entities;

namespace Application.Dto.InstrumentStoreDto;

/// <summary>
/// Базовое дто InstrumentStore
/// </summary>
public class BaseInstrumentStoreDto
{
    /// <summary>
    /// Идентификатор инструмента
    /// </summary>
    public Guid InstrumentId { get; init; }
    
    /// <summary>
    /// Навигационное поле для Instrument
    /// </summary>
    public Instrument Instrument { get; init; }
    
    /// <summary>
    /// Идентификатор магазина
    /// </summary>
    public Guid StoreId { get; init; }
    
    /// <summary>
    /// Навигационное поле для Store
    /// </summary>
    public Store Store { get; init; }
    
    /// <summary>
    /// Кол-во инструментов в магазине
    /// </summary>
    public int Amount { get; init; }
}