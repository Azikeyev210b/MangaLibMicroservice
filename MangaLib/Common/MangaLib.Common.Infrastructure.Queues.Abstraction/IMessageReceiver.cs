using System.Threading.Channels;

namespace Common.Infrastructure.Queues.Abstractions
{
    /// <summary>
    /// Сервис обработки сообщений из очереди
    /// </summary>
    /// <typeparam name="TEvent">Тип обрабатываемого события</typeparam>
    public interface IMessageReceiver<TEvent>
    {
        /// <summary>
        /// Канал для чтения сообщений
        /// </summary>
        ChannelReader<TEvent> Reader { get; }

        /// <summary>
        /// Запуск обработки очереди
        /// </summary>
        Task StartListeningAsync(CancellationToken cancellationToken);
    }
}