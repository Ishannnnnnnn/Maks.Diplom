namespace Application.Dto.ValueObjects;

/// <summary>
/// Дто значимого объекта FullName
/// </summary>
public class FullNameDto
{
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; init; }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; init; }
    
    /// <summary>
    /// Отчество
    /// </summary>
    public string Patronymic { get; init; }
}