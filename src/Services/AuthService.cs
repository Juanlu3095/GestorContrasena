using GestorContrasena.Contracts.Entities.User;
using GestorContrasena.Contracts.Exceptions;
using GestorContrasena.Contracts.Interfaces;
using Npgsql;
using System.Diagnostics;

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

        public bool? Register(UserRegisterInput user)
        {
            try
            {
                var repeatedUsers = this.userQueries.CountByEmail(user.Email);

                if(repeatedUsers == 0)
                {
                    var HashPassword = BCrypt.Net.BCrypt.HashPassword(user.Password, bcryptcost); // Si no se pone, el valor de workFactor es 10
                    user.Password = HashPassword;

                    return this.userModel.Create(user) == 1 ? true : false;

                } else
                {
                    throw new EmailAlreadyExistsException("El email introducido ya existe.");
                }

            } catch (NpgsqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Ha ocurrido un error al obtener los usuarios: " + e);
                return null;
            }
        }

        public bool? Login(UserLoginInput LoginInput)
        {
            try
            {
                var user = this.userModel.GetByEmail(LoginInput.Email);

                if (user == null)
                {
                    return false;
                }

                return BCrypt.Net.BCrypt.Verify(LoginInput.Password, user.Password);
                
            } catch (NpgsqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Ha ocurrido un error al obtener el usuario: " + e);
                return null;
            }
        }

        public bool VerifyLogin()
        {
            return false;
        }

        public bool Logout()
        {
            return false;
        }

        public void ResetPassword()
        {

        }
    }
}
