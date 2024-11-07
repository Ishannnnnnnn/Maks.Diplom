using Domain.Validations.Validators.Entities;
using Domain.ValueObjects;
using FluentValidation;

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
    /// Список заказов
    /// </summary>
    public ICollection<Order> Orders { get; set; } = new List<Order>();

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
        
        Validate();
    }
    
    private void Validate()
    {
        var validator = new StoreValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(" || ", result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
    
    public Store()
    {
    }
}