
namespace GestorContrasena.Contracts.Interfaces
{
    internal interface PasswordCreateViewModelInterface
    {
        public bool AddPasswordAction(string name, string value, string service, string observations);
    }
}
