
namespace GestorContrasena.Contracts.Entities.Password
{
    internal class PasswordInput
    {
        public required string Name { get; set; }
        public required string Value { get; set; }
        public required string Service { get; set; }
        public string? Observations { get; set; }
    }
}
