using GestorContrasena.Contracts.Entities;
using GestorContrasena.Contracts.Interfaces;

namespace GestorContrasena.Services
{
    internal class AuthService : AuthServiceInterface
    {
        private UserModelInterface userModel;

        public AuthService (UserModelInterface userModel)
        {
            this.userModel = userModel;
        }

        public bool Register(UserEntity user)
        {
            return this.userModel.Create(user) == 1 ? true : false;
        }

        public bool Login(UserEntity user)
        {
            return false;
        }

        public bool VerifyLogin()
        {
            return false;
        }

        public bool Logout()
        {
            return false;
        }
    }
}
