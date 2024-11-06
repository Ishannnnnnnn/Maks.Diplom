namespace Domain.Entities;

/// <summary>
/// Служебная таблица связи заказа и инструмента
/// </summary>
public class OrderInstrument : BaseEntity
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public Guid OrderId { get; set; }
    
    /// <summary>
    /// Навигационное поле для Order
    /// </summary>
    public Order Order { get; set; }
    
    /// <summary>
    /// Идентификатор инструмента
    /// </summary>
    public Guid InstrumentId { get; set; }
    
    /// <summary>
    /// Навигационное поле для Instrument
    /// </summary>
    public Instrument Instrument { get; set; }
    
    /// <summary>
    /// Кол-во инструментов в заказе
    /// </summary>
    public int Amount { get; set; }
    
    /// <summary>
    /// Общая цена
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="orderId">Идентификатор заказа.</param>
    /// <param name="order">Заказ.</param>
    /// <param name="instrumentId">Идентификатор инструмента.</param>
    /// <param name="instrument">Инструмент.</param>
    /// <param name="amount">Кол-во инструментов в заказе.</param>
    /// <param name="price">Общая цена.</param>
    public OrderInstrument(
        Guid id,
        Guid orderId,
        Order order,
        Guid instrumentId,
        Instrument instrument,
        int amount,
        decimal price)
    {
        SetId(id);
        OrderId = orderId;
        Order = order;
        InstrumentId = instrumentId;
        Instrument = instrument;
        Amount = amount;
        Price = price;
    }
}