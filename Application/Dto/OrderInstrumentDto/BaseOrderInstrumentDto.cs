using Domain.Entities;

namespace Application.Dto.OrderInstrumentDto;

/// <summary>
/// Базовое дто OrderInstrument
/// </summary>
public class BaseOrderInstrumentDto
{
    /// <summary>
    /// Идентификатор заказа
    /// </summary>
    public Guid OrderId { get; init; }
    
    /// <summary>
    /// Заказ
    /// </summary>
    public Order Order { get; init; }

    /// <summary>
    /// Идентификатор инструмента
    /// </summary>
    public Guid InstrumentId { get; init; }
    
    /// <summary>
    /// Инструмент
    /// </summary>
    public Instrument Instrument { get; init; }

    /// <summary>
    /// Кол-во инструментов в заказе
    /// </summary>
    public int Amount { get; init; }
    
    /// <summary>
    /// Общая цена
    /// </summary>
    public decimal Price { get; init; }
}