namespace Domain.Entities;

/// <summary>
/// Служебная таблица связи инструмента и магазина
/// </summary>
public class InstrumentStore : BaseEntity
{
    /// <summary>
    /// Идентификатор инструмента
    /// </summary>
    public Guid InstrumentId { get; set; }
    
    /// <summary>
    /// Навигационное поле для Instrument
    /// </summary>
    public Instrument Instrument { get; set; }
    
    /// <summary>
    /// Идентификатор магазина
    /// </summary>
    public Guid StoreId { get; set; }
    
    /// <summary>
    /// Навигационное поле для Store
    /// </summary>
    public Store Store { get; set; }
    
    /// <summary>
    /// Кол-во инструментов в магазине
    /// </summary>
    public int Amount { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="instrumentId">Идентификатор инструмента.</param>
    /// <param name="instrument">Инструмент.</param>
    /// <param name="storeId">Идентификатор магазина.</param>
    /// <param name="store">Магазин.</param>
    /// <param name="amount">Кол-во инструментов в магазине.</param>
    public InstrumentStore(
        Guid id,
        Guid instrumentId,
        Instrument instrument,
        Guid storeId,
        Store store,
        int amount)
    {
        SetId(id);
        InstrumentId = instrumentId;
        Instrument = instrument;
        StoreId = storeId;
        Store = store;
        Amount = amount;
    }
}