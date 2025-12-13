using GestorContrasena.Contracts.Entities;

namespace GestorContrasena.Contracts.Interfaces
{
    internal interface AuthModelInterface
    {
        public int? Register(UserEntity user);
    }
}
