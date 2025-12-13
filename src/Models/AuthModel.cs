using GestorContrasena.Contracts.Entities;
using GestorContrasena.Contracts.Interfaces;
using Npgsql;

namespace GestorContrasena.Models
{
    internal class AuthModel : AuthModelInterface
    {
        private readonly DbConnectionInterface connection;

        public AuthModel (DbConnectionInterface connection)
        {
            this.connection = connection;
        }

        public int? Register(UserEntity user)
        {
            try
            {
                var dbconnection = this.connection.CreateConnection();
                dbconnection?.Open();
                var sqlCommand = new NpgsqlCommand("INSERT INTO users (name, email, password) VALUES (@name,@email,@password)", dbconnection);
                sqlCommand.Parameters.AddWithValue("name", user.Name);
                sqlCommand.Parameters.AddWithValue("email", user.Email);
                sqlCommand.Parameters.AddWithValue("password", user.Password);
                var result = sqlCommand.ExecuteNonQuery();
                dbconnection?.Close();
                return result;

            } catch (NpgsqlException e)
            {
                MessageBox.Show("Ha ocurrido un error al ejecutar el registro: " + e.ToString());
                return null;
            }
        }

        public void Login()
        {

        }

        public void VerifyLogin()
        {

        }

        public void Logout()
        {

        }
    }
}
