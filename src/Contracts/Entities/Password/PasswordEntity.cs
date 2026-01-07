
namespace GestorContrasena.Contracts.Entities.Password
{
    internal class PasswordEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Service { get; set; }
        public string? Observations { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
