using Domain.ValueObjects;

namespace Domain.Entities;

/// <summary>
/// Сущность магазина
/// </summary>
public class Store : BaseEntity
{
    /// <summary>
    /// Адрес
    /// </summary>
    public Address Address { get; set; }
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string Phone { get; set; }
    
    /// <summary>
    /// Список связей InstrumentStore
    /// </summary>
    public ICollection<InstrumentStore> InstrumentStores { get; set; } = new List<InstrumentStore>();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="address">Адрес.</param>
    /// <param name="phone">Номер телефона.</param>
    public Store(
        Guid id,
        Address address,
        string phone)
    {
        SetId(id);
        Address = address;
        Phone = phone;
    }
}