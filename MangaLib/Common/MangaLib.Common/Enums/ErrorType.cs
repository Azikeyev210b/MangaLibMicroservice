namespace Common.Enums
{
    /// <summary>
    /// Типы ошибок приложения
    /// </summary>
    public enum ErrorType
    {
        Validation,   // Ошибка валидации
        NotFound,     // Сущность не найдена
        Conflict,     // Конфликт данных
        Internal      // Внутренняя ошибка сервера
    }
}