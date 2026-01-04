
namespace GestorContrasena.Contracts.Entities.Password
{
    internal class PasswordEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string? Service { get; set; }
        public string? Observations { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }
    }
}
