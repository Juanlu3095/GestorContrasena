
using GestorContrasena.Contracts.Entities.Password;

namespace GestorContrasena.Contracts.Interfaces
{
    internal interface PasswordModelInterface
    {
        public List<PasswordEntity> GetAll();
        public PasswordEntity? GetById(Guid id);
        public int? Create(PasswordInput password);
    }
}
