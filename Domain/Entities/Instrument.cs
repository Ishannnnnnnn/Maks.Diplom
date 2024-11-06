using Domain.Primitives;

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
    }
}