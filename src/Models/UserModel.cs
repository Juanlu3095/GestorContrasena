using GestorContrasena.Contracts.Entities.User;
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
                var sqlCommand = new NpgsqlCommand("SELECT name, email from users;", dbconnection);
                var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    UserEntity user = new UserEntity();
                    user.Id = reader.GetGuid(reader.GetOrdinal("id"));
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

        public UserEntity? GetById(Guid id)
        {
            UserEntity? user = null;

            try
            {
                var dbconnection = this.connection.CreateConnection();
                dbconnection?.Open();
                var sqlCommand = new NpgsqlCommand("SELECT name, email from users WHERE id = @id", dbconnection);
                sqlCommand.Parameters.AddWithValue("id", id);
                var reader = sqlCommand.ExecuteReader();
                
                if (reader.Read())
                {
                    user = new UserEntity();
                    user.Id = reader.GetGuid(reader.GetOrdinal("id"));
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

        public UserEntity? GetByEmail(string email)
        {
            UserEntity? user = null; // Necesitamos hacer esto null para que en el caso de no encontrar ninguna fila, el resto de componentes pueda comprobarlo fácilmente.

            try
            {
                var dbconnection = this.connection.CreateConnection();
                dbconnection?.Open();
                var sqlCommand = new NpgsqlCommand("SELECT name, email, password from users WHERE email = @email", dbconnection);
                sqlCommand.Parameters.AddWithValue("email", email);
                var reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    user = new UserEntity(); // Aquí si hay user, le pasamos las columnas
                    user.Name = reader.GetString(reader.GetOrdinal("name"));
                    user.Email = reader.GetString(reader.GetOrdinal("email"));
                    user.Password = reader.GetString(reader.GetOrdinal("password"));
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

        public int? Create(UserRegisterInput user)
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
                System.Diagnostics.Debug.WriteLine("Ha ocurrido un error al crear el usuario: " + e);
                return null;
            }
        }

        public int? Update (UserEntity user) // Ver si es necesario mantener la id aquí o se coge la que lleve UserEntity
        {
            try
            {
                var dbconnection = this.connection.CreateConnection();
                dbconnection?.Open();
                var sqlCommand = new NpgsqlCommand("UPDATE users SET name = @name, email = @email, password = @password WHERE id = @id", dbconnection);
                sqlCommand.Parameters.AddWithValue("id", user.Id);
                sqlCommand.Parameters.AddWithValue("name", user.Name);
                sqlCommand.Parameters.AddWithValue("email", user.Email);
                sqlCommand.Parameters.AddWithValue("password", user.Password);
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
        public int? Delete(Guid id)
        {
            try
            {
                var dbconnection = this.connection.CreateConnection();
                dbconnection?.Open();
                var sqlCommand = new NpgsqlCommand("DELETE FROM users WHERE id = @id", dbconnection);
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
