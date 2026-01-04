
using GestorContrasena.Contracts.Entities.Password;
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

            try
            {
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
                    password.Created_at = reader.GetString(reader.GetOrdinal("created_at"));
                    password.Updated_at = reader.GetString(reader.GetOrdinal("updated_at"));

                    passwords.Add(password);
                }

                dbconnection?.Close();
                return passwords;
            }
            catch (NpgsqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Ha ocurrido un error al obtener los usuarios: " + e);
                return null;
            }
        }
    }
}
