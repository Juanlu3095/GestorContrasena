using GestorContrasena.Contracts.Interfaces;
using Npgsql;

namespace GestorContrasena.Database.Queries
{
    internal class UserQueries : UserQueriesInterface
    {
        readonly private DbConnectionInterface connection; // Esto se puede hacer readonly aunque se deba usar el contructor para pasarle connection ??

        public UserQueries(DbConnectionInterface connection)
        {
            this.connection = connection;
        }

        public int? CountByEmail(string email)
        {
            int counter = 0;
            try
            {
                var dbconnection = this.connection.CreateConnection();
                dbconnection?.Open();
                var sqlCommand = new NpgsqlCommand("SELECT COUNT(*) as conteo from users WHERE email = @email", dbconnection);
                sqlCommand.Parameters.AddWithValue("email", email);
                var reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    counter = reader.GetInt32(0);
                }

                dbconnection?.Close();
                return counter;
            }
            catch (NpgsqlException e)
            {
                System.Diagnostics.Debug.WriteLine("Ha ocurrido un error al obtener el número de usuarios con el email indicado: " + e);
                return null;
            }
        }
    }
}
