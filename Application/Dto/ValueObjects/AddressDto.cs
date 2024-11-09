namespace Application.Dto.ValueObjects;

/// <summary>
/// Дто значимого объекта AddressDto
/// </summary>
public class AddressDto
{
    /// <summary>
    /// Город
    /// </summary>
    public string City { get; init; }
    
    /// <summary>
    /// Улица
    /// </summary>
    public string Street { get; init; }
    
    /// <summary>
    /// Номер дома
    /// </summary>
    public int HouseNumber { get; init; }
}