using GestorContrasena.Contracts.Entities.User;

namespace GestorContrasena.Contracts.Interfaces
{
    internal interface AuthServiceInterface
    {
        public bool Register(UserRegisterInput user);

        public bool Login(UserLoginInput user);

        public bool VerifyLogin();

        public bool Logout();
    }
}
