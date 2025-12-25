using GestorContrasena.Common;
using GestorContrasena.Contracts.Entities.User;
using GestorContrasena.Contracts.Exceptions;
using GestorContrasena.Contracts.Interfaces;

namespace GestorContrasena.Services
{
    internal class AuthService : AuthServiceInterface
    {
        private UserModelInterface userModel;
        private UserQueriesInterface userQueries;
        private int bcryptcost; // Esto no hace falta usarlo al validar la contraseña porque la contraseña hasheada ya tiene este coste dentro.

        public AuthService (UserModelInterface userModel, UserQueriesInterface userQueries, int bcryptcost)
        {
            this.userModel = userModel;
            this.userQueries = userQueries;
            this.bcryptcost = bcryptcost != 0 ? bcryptcost : 12;
        }

        public bool Register(UserRegisterInput user)
        {
            var repeatedUsers = this.userQueries.CountByEmail(user.Email);

            if (repeatedUsers == 0)
            {
                var HashPassword = BCrypt.Net.BCrypt.HashPassword(user.Password, bcryptcost); // Si no se pone, el valor de workFactor es 10
                user.Password = HashPassword;

                return this.userModel.Create(user) == 1 ? true : false;

            }
            else
            {
                throw new EmailAlreadyExistsException("El email introducido ya existe.");
            }
        }

        public bool Login(UserLoginInput LoginInput)
        {
            var user = this.userModel.GetByEmail(LoginInput.Email);

            if (user == null)
            {
                throw new InvalidCredentialsException("Credenciales incorrectas.");
            }

            var loginResult = BCrypt.Net.BCrypt.Verify(LoginInput.Password, user.Password);

            if (!loginResult)
            {
                throw new InvalidCredentialsException("Credenciales incorrectas.");
            }

            Session.Initialize(user.Id, user.Name, user.Email);

            return true;
        }

        public bool VerifyLogin()
        {
            return Session.IsAuthenticated();
        }

        public bool Logout()
        {
            Session.End();
            return !Session.IsAuthenticated();
        }

        public void ResetPassword()
        {

        }
    }
}
