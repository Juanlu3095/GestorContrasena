using Npgsql;
using GestorContrasena.Contracts.Interfaces;

namespace GestorContrasena.Database
{
    public class Connection : DbConnectionInterface
    {
        private string Host;
        private int Port;
        private string Dbname;
        private string User;
        private string Password;
        private string Url;

        public Connection (
            string Host,
            int Port,
            string Dbname,
            string User,
            string Password
        )
        {
            this.Host = Host;
            this.Port = Port;
            this.Dbname = Dbname;
            this.User = User;
            this.Password = Password;
            this.Url = "Host=" + this.Host + ";Username=" + this.User + ";Password=" + this.Password + ";Database=" + this.Dbname;
        }

        public NpgsqlConnection? CreateConnection()
        {
            try
            {
                var connection = new NpgsqlConnection(this.Url);
                return connection;
            } catch (NpgsqlException e)
            {
                MessageBox.Show("No se ha podido conectar a la base de datos. Error: " + e.ToString());
                return null;
            }
            
        }
    }
}
