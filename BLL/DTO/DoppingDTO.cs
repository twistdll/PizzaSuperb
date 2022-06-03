namespace BLL.DTO
{
    public record DoppingDTO
    {
        public string Name { get; init; }
        public double Price { get; init; }
        public string? PhotoUrl { get; init; }
    }
}
