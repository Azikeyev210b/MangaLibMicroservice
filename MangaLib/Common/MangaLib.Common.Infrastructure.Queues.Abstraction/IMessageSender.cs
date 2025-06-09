namespace Common.Infrastructure.Queues.Abstractions
{
    /// <summary>
    /// Сервис отправки сообщений в очередь
    /// </summary>
    /// <typeparam name="TEvent">Тип отправляемого события</typeparam>
    public interface IMessageSender<TEvent>
    {
        /// <summary>
        /// Отправить сообщение
        /// </summary>
        /// <param name="message">Данные сообщения</param>
        /// <param name="delay">Задержка в миллисекундах (опционально)</param>
        Task SendAsync(TEvent message, long? delay = null);
    }
}