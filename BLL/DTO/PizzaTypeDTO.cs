namespace BLL.DTO
{
    public record PizzaTypeDTO
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public double Price { get; init; }
        public double TotalPrice { get; init; }
    }
}
