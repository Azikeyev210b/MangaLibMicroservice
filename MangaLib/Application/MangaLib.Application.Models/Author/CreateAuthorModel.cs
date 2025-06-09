namespace Application.Models
{
    public record CreateAuthorModel(
        string Name) : ICreateModel;
}