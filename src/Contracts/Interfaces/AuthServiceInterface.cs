using GestorContrasena.Contracts.Entities;

namespace GestorContrasena.Contracts.Interfaces
{
    internal interface AuthServiceInterface
    {
        public bool Register(UserEntity user);

        public bool Login(UserEntity user);

        public bool VerifyLogin();

        public bool Logout();
    }
}
