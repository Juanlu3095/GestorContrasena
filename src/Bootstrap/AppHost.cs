using GestorContrasena.Database;
using GestorContrasena.Models;
using GestorContrasena.ViewModels;
using GestorContrasena.Views;
using static Class1;

namespace GestorContrasena.Bootstrap
{
    internal class AppHost
    {
        string host;
        int port;
        string dbname;
        string user;
        string password;

        public Connection Connection;
        public AuthModel AuthModel;
        public RegisterViewModel RegisterViewModel;
        public Register RegisterView;

        public AppHost ()
        {
            var root = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.Parent!.FullName; // Obtiene el directorio actual subiendo de carpeta con Parent
            var dotenv = Path.Combine(root, ".env");
            DotEnv.Load(dotenv);

            this.host = Environment.GetEnvironmentVariable("host");
            this.port = Convert.ToInt32(Environment.GetEnvironmentVariable("port"));
            this.dbname = Environment.GetEnvironmentVariable("dbname");
            this.user = Environment.GetEnvironmentVariable("user");
            this.password = Environment.GetEnvironmentVariable("password");

            // Database connection configuration
            Connection = new Connection(host, port, dbname, user, password);

            // Models
            AuthModel = new AuthModel(this.Connection);

            // ViewModels
            RegisterViewModel = new RegisterViewModel(AuthModel);

            // Views
            RegisterView = new Register(RegisterViewModel);

            // Events for navigation
            RegisterViewModel.OnNavigate += Navigate;
            
        }

        // It allows to open or close the views.
        public void Navigate(string destino)
        {
            switch(destino)
            {
                case "InicioSesion":
                    System.Diagnostics.Debug.WriteLine("Ha llegado el evento");
                    break;

                case "Registro":
                    break;

                case "ListadoContrasenas":
                    break;
            }
        }
    }
}
