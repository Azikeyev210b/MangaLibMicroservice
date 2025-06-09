namespace Application.Models
{
    public record PagedModel<T>(
        IEnumerable<T> Items,
        int TotalCount,
        int PageNumber,
        int PageSize);
}