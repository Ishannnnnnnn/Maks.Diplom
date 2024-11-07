namespace Domain.Validations;

/// <summary>
/// Класс сообщений об ошибках валидации
/// </summary>
public static class ValidationMessages
{
    public const string NullError = "{PropertyName} не может быть null";
    public const string EmptyError = "{PropertyName} не может быть пустым";
    
    public const string MinimumLengthError = "{PropertyName} слишком короткий";
    public const string MaximumLengthError = "{PropertyName} слишком длинный";
    
    public const string OnlyLettersError = "{PropertyName} должен содержать только буквы";
    public const string EmailError = "Почта неверного формата";
    public const string PhoneError = "Телефон неверного формата";
    
    public const string EnumError = "{PropertyName} не должен быть None";
    public const string NegativeOrZeroNumberError = "{PropertyName} не может быть отрицательным или ноль";
    public const string DecimalPlacesError = "{PropertyName} не должен содержать более 2х знаков после запятой";
    public const string FutureDateError = "{PropertyName} не может быть в будущем";
}