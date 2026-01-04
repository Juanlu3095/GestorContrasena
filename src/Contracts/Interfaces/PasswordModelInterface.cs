
using GestorContrasena.Contracts.Entities.Password;

namespace GestorContrasena.Contracts.Interfaces
{
    internal interface PasswordModelInterface
    {
        public List<PasswordEntity> GetAll();
    }
}
