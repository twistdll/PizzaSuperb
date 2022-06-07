namespace BLL.DTO
{
    public record UserDTO
    {
        public int Id { get; }
        public string Name { get; init; }
        public string? Email { get; init; }
        public string Telephone { get; init; }
        public string Password { get; init; }
        public DateTime DateCreated { get; init; }
    }
}