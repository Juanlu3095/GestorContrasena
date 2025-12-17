using GestorContrasena.Database;
using GestorContrasena.Models;
using GestorContrasena.ViewModels;
using GestorContrasena.Views;
using GestorContrasena.Utilities;
using GestorContrasena.Services;
using GestorContrasena.Database.Queries;

namespace GestorContrasena.Bootstrap
{
    internal class AppHost
    {
        readonly string host;
        readonly int port;
        readonly string dbname;
        readonly string user;
        readonly string password;

        private Connection Connection;
        private UserModel UserModel;
        private UserQueries UserQueries;
        private AuthService AuthService; 
        private RegisterViewModel RegisterViewModel;
        public Register RegisterView;

        public AppHost ()
        {
            var root = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.Parent!.FullName; // Obtiene el directorio actual subiendo de carpeta con Parent
            var dotenv = Path.Combine(root, ".env");
            DotEnv.Load(dotenv);

            this.host = Environment.GetEnvironmentVariable("host") ?? "localhost";
            this.port = Convert.ToInt32(Environment.GetEnvironmentVariable("port"));
            this.dbname = Environment.GetEnvironmentVariable("dbname") ?? "postgres";
            this.user = Environment.GetEnvironmentVariable("user") ?? "root";
            this.password = Environment.GetEnvironmentVariable("password") ?? "";

            // Database connection configuration
            Connection = new Connection(host, port, dbname, user, password);

            // Models
            UserModel = new UserModel(this.Connection);

            // Queries
            UserQueries = new UserQueries(this.Connection);

            // Services
            AuthService = new AuthService(this.UserModel, this.UserQueries);

            // ViewModels
            RegisterViewModel = new RegisterViewModel(this.AuthService);

            // Views
            RegisterView = new Register(this.RegisterViewModel);

            // Events for navigation
            RegisterViewModel.OnNavigate += Navigate;
            
        }

        // It allows to open or close the views.
        public void Navigate(string destino)
        {
            switch(destino)
            {
                case "InicioSesion":
                    System.Diagnostics.Debug.WriteLine("Ha llegado el evento para inicio sesión");
                    break;

                case "Registro":
                    break;

                case "ListadoContrasenas":
                    break;
            }
        }
    }
}
