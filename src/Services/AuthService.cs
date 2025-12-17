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

        public AuthService (UserModelInterface userModel, UserQueriesInterface userQueries)
        {
            this.userModel = userModel;
            this.userQueries = userQueries;
        }

        public bool? Register(UserEntity user)
        {
            try
            {
                var repeatedUsers = this.userQueries.CountByEmail(user.Email);

                if(repeatedUsers == 0)
                {
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
