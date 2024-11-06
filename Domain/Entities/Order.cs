namespace Domain.Entities;

/// <summary>
/// Сущность заказа
/// </summary>
public class Order : BaseEntity
{
    /// <summary>
    /// Дата заказа
    /// </summary>
    public DateTime OrderDate { get; set; }
    
    /// <summary>
    /// Идентификатор магазина
    /// </summary>
    public Guid StoreId { get; set; }
    
    /// <summary>
    /// Навигационное поле для Store
    /// </summary>
    public Store Store { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Навигационное поле для User
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Список связей OrderInstrument
    /// </summary>
    public ICollection<OrderInstrument> OrderInstruments { get; set; } = new List<OrderInstrument>();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="orderDate">Дата заказа.</param>
    /// <param name="storeId">Идентификатор магазина.</param>
    /// <param name="store">Магазин.</param>
    /// <param name="userId">Идентификатор пользователя.</param>
    /// <param name="user">Пользователь.</param>
    public Order(
        Guid id,
        DateTime orderDate,
        Guid storeId,
        Store store,
        Guid userId,
        User user)
    {
        SetId(id);
        OrderDate = orderDate;
        StoreId = storeId;
        Store = store;
        UserId = userId;
        User = user;
    }
}