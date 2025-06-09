namespace Application.Models
{
    public record EntityModel<TId>(TId Id, string Name)
        : IModel<TId> where TId : struct, IEquatable<TId>;
}