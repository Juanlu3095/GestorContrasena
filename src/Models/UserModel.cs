using GestorContrasena.Contracts.Entities;
using GestorContrasena.Contracts.Interfaces;
using Npgsql;

namespace GestorContrasena.Models
{
    internal class UserModel : UserModelInterface
    {
        private readonly DbConnectionInterface connection;

        public UserModel (DbConnectionInterface connection)
        {
            this.connection = connection;
        }

        public List<UserEntity>? GetAll()
        {
            List<UserEntity> users = new List<UserEntity>();

            try
            {
                var dbconnection = this.connection.CreateConnection();
                dbconnection?.Open();
                var sqlCommand = new NpgsqlCommand("SELECT name, email from users;", dbconnection); // Crear id más segura
                var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    UserEntity user = new UserEntity();
                    user.Id = reader.GetString(reader.GetOrdinal("id"));
                    user.Name = reader.GetString(reader.GetOrdinal("name"));
                    user.Email = reader.GetString(reader.GetOrdinal("email"));

                    users.Add(user);
                }

                dbconnection?.Close();
                return users;
            }
            catch (NpgsqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Ha ocurrido un error al obtener los usuarios: " + e);
                return null;
            }
        }

        public UserEntity? GetById(int id)
        {
            UserEntity user = new UserEntity();

            try
            {
                var dbconnection = this.connection.CreateConnection();
                dbconnection?.Open();
                var sqlCommand = new NpgsqlCommand("SELECT name, email from users WHERE id = @id", dbconnection); // Crear id más segura
                sqlCommand.Parameters.AddWithValue("id", id);
                var reader = sqlCommand.ExecuteReader();
                
                while (reader.Read())
                {
                    user.Id = reader.GetString(reader.GetOrdinal("id"));
                    user.Name = reader.GetString(reader.GetOrdinal("name"));
                    user.Email = reader.GetString(reader.GetOrdinal("email"));
                }

                dbconnection?.Close();
                return user;
            }
            catch (NpgsqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Ha ocurrido un error al obtener el usuario: " + e);
                return null;
            }
        }

        public int? Create(UserEntity user)
        {
            try
            {
                var dbconnection = this.connection.CreateConnection();
                dbconnection?.Open();
                var sqlCommand = new NpgsqlCommand("INSERT INTO users (name, email, password) VALUES (@name,@email,@password)", dbconnection); // Crear id más segura
                sqlCommand.Parameters.AddWithValue("name", user.Name);
                sqlCommand.Parameters.AddWithValue("email", user.Email);
                sqlCommand.Parameters.AddWithValue("password", user.Password); // Encriptar esto
                var result = sqlCommand.ExecuteNonQuery();
                dbconnection?.Close();
                return result;

            } catch (NpgsqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Ha ocurrido un error al crear el usuario: " + e);
                return null;
            }
        }

        public int? Update (int id, UserEntity user)
        {
            try
            {
                var dbconnection = this.connection.CreateConnection();
                dbconnection?.Open();
                var sqlCommand = new NpgsqlCommand("UPDATE users SET name = @name, email = @email, password = @password WHERE id = @id", dbconnection); // Crear id más segura
                sqlCommand.Parameters.AddWithValue("id", user.Id);
                sqlCommand.Parameters.AddWithValue("name", user.Name);
                sqlCommand.Parameters.AddWithValue("email", user.Email);
                sqlCommand.Parameters.AddWithValue("password", user.Password); // Encriptar esto
                var result = sqlCommand.ExecuteNonQuery();
                dbconnection?.Close();
                return result;

            }
            catch (NpgsqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Ha ocurrido un error al crear el usuario: " + e);
                return null;
            }
        }
        public int? Delete(int id)
        {
            try
            {
                var dbconnection = this.connection.CreateConnection();
                dbconnection?.Open();
                var sqlCommand = new NpgsqlCommand("DELETE FROM users WHERE id = @id", dbconnection); // Crear id más segura
                sqlCommand.Parameters.AddWithValue("id", id);
                var result = sqlCommand.ExecuteNonQuery();
                dbconnection?.Close();
                return result;
            }
            catch (NpgsqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Ha ocurrido un error en el registro: " + e);
                return null;
            }
        }

    }
}
