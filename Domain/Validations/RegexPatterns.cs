using System.Text.RegularExpressions;

namespace Domain.Validations;

/// <summary>
/// Условные выражения
/// </summary>
public static class RegexPatterns
{
    /// <summary>
    /// Строки (только буквы)
    /// </summary>
    public static readonly Regex LettersPattern = new ("\\p{L}'?$");

    /// <summary>
    /// Электронная почта
    /// </summary>
    public static readonly Regex EmailPattern = new("([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\\.[a-zA-Z0-9_-]+)");
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    public static readonly Regex PhonePattern = new(@"^373\d{8}$");
    
}