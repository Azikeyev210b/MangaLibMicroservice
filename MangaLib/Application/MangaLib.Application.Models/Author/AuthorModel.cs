namespace Application.Models
{
    public record AuthorModel(
        int Id,
        string Name,
        IEnumerable<string> Works) : IModel<int>;
}