using Domain.Primitives;
using Domain.Validations.Validators.Entities;
using FluentValidation;

namespace Domain.Entities;

/// <summary>
/// Сущность инструмента
/// </summary>
public class Instrument : BaseEntity
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Категория
    /// </summary>
    public Category Category { get; set; }
    
    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Список связей InstrumentStore
    /// </summary>
    public ICollection<InstrumentStore> InstrumentStores { get; set; } = new List<InstrumentStore>();
    
    /// <summary>
    /// Список связей OrderInstrument
    /// </summary>
    public ICollection<OrderInstrument> OrderInstruments { get; set; } = new List<OrderInstrument>();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="name">Название.</param>
    /// <param name="category">Категория.</param>
    /// <param name="price">Цена.</param>
    public Instrument(
        Guid id,
        string name,
        Category category,
        decimal price)
    {
        SetId(id);
        Name = name;
        Category = category;
        Price = price;
        
        Validate();
    }
    
    private void Validate()
    {
        var validator = new InstrumentValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(" || ", result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }

    public Instrument()
    {
    }
}