
using GestorContrasena.Contracts.Entities.Password;
using GestorContrasena.Contracts.Exceptions;
using GestorContrasena.Contracts.Interfaces;
using Npgsql;

namespace GestorContrasena.Models
{
    internal class PasswordModel : PasswordModelInterface
    {
        private readonly DbConnectionInterface connection;

        public PasswordModel (DbConnectionInterface connection)
        {
            this.connection = connection;
        }

        public List<PasswordEntity> GetAll()
        {
            List<PasswordEntity> passwords = new List<PasswordEntity>();

            var dbconnection = this.connection.CreateConnection();
            dbconnection?.Open();
            var sqlCommand = new NpgsqlCommand("SELECT * from passwords;", dbconnection);
            var reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                PasswordEntity password = new();
                password.Id = reader.GetGuid(reader.GetOrdinal("id"));
                password.Name = reader.GetString(reader.GetOrdinal("name"));
                password.Value = reader.GetString(reader.GetOrdinal("value"));
                password.Service = reader.GetString(reader.GetOrdinal("service"));
                password.Observations = reader.GetString(reader.GetOrdinal("observations"));
                password.Created_at = reader.GetDateTime(reader.GetOrdinal("created_at"));
                password.Updated_at = reader.GetDateTime(reader.GetOrdinal("updated_at"));

                passwords.Add(password);
            }

            dbconnection?.Close();
            return passwords;
        }

        public List<PasswordEntity>? GetByName(string name)
        {
            String nameToLowerCase = name.ToLower(); // POSTGRESQL ES SENSIBLE A MINÚSCULAS Y MAYÚSCULAS

            try
            {
                List<PasswordEntity> passwords = new List<PasswordEntity>();

                var dbconnection = this.connection.CreateConnection();
                dbconnection?.Open();
                var sqlCommand = new NpgsqlCommand("SELECT * from passwords WHERE LOWER(name) LIKE @name", dbconnection);
                sqlCommand.Parameters.AddWithValue("name", '%' + nameToLowerCase + '%'); 
                var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    PasswordEntity password = new();
                    password.Id = reader.GetGuid(reader.GetOrdinal("id"));
                    password.Name = reader.GetString(reader.GetOrdinal("name"));
                    password.Value = reader.GetString(reader.GetOrdinal("value"));
                    password.Service = reader.GetString(reader.GetOrdinal("service"));
                    password.Observations = reader.GetString(reader.GetOrdinal("observations"));
                    password.Created_at = reader.GetDateTime(reader.GetOrdinal("created_at"));
                    password.Updated_at = reader.GetDateTime(reader.GetOrdinal("updated_at"));

                    passwords.Add(password);
                }

                dbconnection?.Close();

                if (passwords.Count == 0) throw new ResourceNotFoundException("No se ha podido encontrar el elemento con el término indicado.");

                return passwords;
            }
            catch (NpgsqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Ha ocurrido un error al obtener la contraseña: " + e);
                return null;
            }
        }

        public PasswordEntity? GetById(Guid id)
        {
            PasswordEntity? password = null;

            try
            {
                var dbconnection = this.connection.CreateConnection();
                dbconnection?.Open();
                var sqlCommand = new NpgsqlCommand("SELECT * from passwords WHERE id = @id", dbconnection);
                sqlCommand.Parameters.AddWithValue("id", id);
                var reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    password = new PasswordEntity();
                    password.Id = reader.GetGuid(reader.GetOrdinal("id"));
                    password.Name = reader.GetString(reader.GetOrdinal("name"));
                    password.Value = reader.GetString(reader.GetOrdinal("value"));
                    password.Service = reader.GetString(reader.GetOrdinal("service"));
                    password.Observations = reader.GetString(reader.GetOrdinal("observations"));
                    password.Created_at = reader.GetDateTime(reader.GetOrdinal("created_at"));
                    password.Updated_at = reader.GetDateTime(reader.GetOrdinal("updated_at"));
                }

                dbconnection?.Close();
                return password;
            }
            catch (NpgsqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Ha ocurrido un error al obtener la contraseña: " + e);
                return null;
            }
        }

        public int? Create(PasswordInput password)
        {
            try
            {
                var dbconnection = this.connection.CreateConnection();
                dbconnection?.Open();
                var sqlCommand = new NpgsqlCommand("INSERT INTO passwords (name, value, service, observations) VALUES (@name,@value,@service, @observations)", dbconnection);
                sqlCommand.Parameters.AddWithValue("name", password.Name);
                sqlCommand.Parameters.AddWithValue("value", password.Value);
                sqlCommand.Parameters.AddWithValue("service", password.Service);
                sqlCommand.Parameters.AddWithValue("observations", password.Observations ?? "");
                var result = sqlCommand.ExecuteNonQuery();
                dbconnection?.Close();

                if (!(result > 0)) throw new ResourceNotCreatedException("Ha ocurrido un error al crear el elemento.");

                return result;

            }
            catch (NpgsqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Ha ocurrido un error al crear el registro: " + e);
                return null;
            }
        }

        public int? Update(Guid id, PasswordInput password) // Ver si es necesario mantener la id aquí o se coge la que lleve PasswordEntity
        {
            try
            {
                var dbconnection = this.connection.CreateConnection();
                dbconnection?.Open();
                var sqlCommand = new NpgsqlCommand("UPDATE passwords SET name = @name, value = @value, service = @service, observations = @observations WHERE id = @id", dbconnection);
                sqlCommand.Parameters.AddWithValue("id", id);
                sqlCommand.Parameters.AddWithValue("name", password.Name);
                sqlCommand.Parameters.AddWithValue("name", password.Value);
                sqlCommand.Parameters.AddWithValue("name", password.Service);
                sqlCommand.Parameters.AddWithValue("name", password.Observations ?? "");
                var result = sqlCommand.ExecuteNonQuery();
                dbconnection?.Close();

                if (!(result > 0)) throw new ResourceNotFoundException("Registro no encontrado.");

                return result;

            }
            catch (NpgsqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Ha ocurrido un error al editar el registro: " + e);
                return null;
            }
        }

        public int? Delete(Guid id)
        {
            try
            {
                var dbconnection = this.connection.CreateConnection();
                dbconnection?.Open();
                var sqlCommand = new NpgsqlCommand("DELETE FROM passwords WHERE id = @id", dbconnection);
                sqlCommand.Parameters.AddWithValue("id", id);
                var result = sqlCommand.ExecuteNonQuery();
                dbconnection?.Close();

                if (!(result > 0)) throw new ResourceNotDeletedException("Ha ocurrido un error al eliminar el elemento.");

                return result;
            }
            catch (NpgsqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Ha ocurrido un error al eliminar el registro: " + e);
                return null;
            }
        }
    }
}
