using Domain.Primitives;

namespace Application.Dto.InstrumentDto;

/// <summary>
/// Базовое дто Instrument
/// </summary>
public class BaseInstrumentDto
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; init; }
    
    /// <summary>
    /// Категория
    /// </summary>
    public Category Category { get; init; }
    
    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; init; }
}