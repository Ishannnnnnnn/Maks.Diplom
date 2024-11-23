namespace Domain.Entities;

/// <summary>
/// Базовая сущность
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Метод установки идентификатора
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    protected void SetId(Guid id)
    {
        Id = id;
    }
}