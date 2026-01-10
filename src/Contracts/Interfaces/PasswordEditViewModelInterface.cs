
using GestorContrasena.Contracts.Entities.Password;

namespace GestorContrasena.Contracts.Interfaces
{
    internal interface PasswordEditViewModelInterface
    {
        PasswordEntity GetPassword(Guid id);
        void EditPassword(Guid id, string name, string value, string service, string observations);

    }
}
