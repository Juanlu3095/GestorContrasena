using GestorContrasena.Contracts.Entities;
using GestorContrasena.Contracts.Exceptions;
using GestorContrasena.Contracts.Interfaces;
using Npgsql;

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

        public bool? Register(UserEntity user)
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

        public void ResetPassword()
        {

        }
    }
}
