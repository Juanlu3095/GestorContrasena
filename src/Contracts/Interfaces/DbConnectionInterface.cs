using Npgsql;

namespace GestorContrasena.Contracts.Interfaces
{
    interface DbConnectionInterface
    {
        public NpgsqlConnection? CreateConnection();
    }
}
