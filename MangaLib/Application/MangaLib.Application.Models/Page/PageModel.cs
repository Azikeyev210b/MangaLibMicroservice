namespace Application.Models
{
    public record PageModel(
        int Id,
        int Number,
        string ImageUrl) : IModel<int>;
}