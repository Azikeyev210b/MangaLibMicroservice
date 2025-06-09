namespace Common.Infrastructure.Queues.Abstractions
{
    /// <summary>
    /// Маркерный интерфейс для очереди
    /// </summary>
    /// <typeparam name="T">Тип идентификатора очереди (string, enum и т.д.)</typeparam>
    public interface IQueue<T>
    {
        T QueueName { get; }
    }
}