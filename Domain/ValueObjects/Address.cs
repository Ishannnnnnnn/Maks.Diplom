namespace Domain.ValueObjects;

/// <summary>
/// Адрес
/// </summary>
public abstract class Address
{
    /// <summary>
    /// Город
    /// </summary>
    public string City { get; private set; }
    
    /// <summary>
    /// Улица
    /// </summary>
    public string Street { get; private set; }
    
    /// <summary>
    /// Номер дома
    /// </summary>
    public int HouseNumber { get; private set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="city">Город.</param>
    /// <param name="street">Улица.</param>
    /// <param name="houseNumber">Номер дома.</param>
    protected Address(
        string city,
        string street,
        int houseNumber)
    {
        City = city;
        Street = street;
        HouseNumber = houseNumber;
    }
}