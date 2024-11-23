using Application.Dto.ValueObjects;

namespace Application.Dto.StoreDto;

/// <summary>
/// Базовое дто Store
/// </summary>
public class BaseStoreDto
{
    /// <summary>
    /// Адрес
    /// </summary>
    public AddressDto Address { get; init; }
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string Phone { get; init; }
}