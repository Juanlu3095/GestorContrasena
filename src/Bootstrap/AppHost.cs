using GestorContrasena.Database;
using GestorContrasena.Models;
using GestorContrasena.ViewModels;
using GestorContrasena.Views;
using GestorContrasena.Utilities;
using GestorContrasena.Services;
using GestorContrasena.Database.Queries;
using GestorContrasena.Views.Passwords;

namespace GestorContrasena.Bootstrap
{
    internal class AppHost
    {
        readonly string host;
        readonly int port;
        readonly string dbname;
        readonly string user;
        readonly string password;
        readonly int bcryptcost;

        private Connection Connection;
        private UserModel UserModel;
        private PasswordModel PasswordModel;
        private UserQueries UserQueries;
        private AuthService AuthService; 
        private RegisterViewModel RegisterViewModel;
        private LoginViewModel LoginViewModel;
        private PasswordListViewModel PasswordListViewModel;
        public Register RegisterView;
        public Login LoginView;
        public PasswordList PasswordList;

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
            this.bcryptcost = Convert.ToInt32(Environment.GetEnvironmentVariable("bcryptcost"));

            // Database connection configuration
            Connection = new Connection(host, port, dbname, user, password);

            // Models
            UserModel = new UserModel(this.Connection);
            PasswordModel = new PasswordModel(this.Connection);

            // Queries
            UserQueries = new UserQueries(this.Connection);

            // Services
            AuthService = new AuthService(this.UserModel, this.UserQueries, this.bcryptcost);

            // ViewModels
            RegisterViewModel = new RegisterViewModel(this.AuthService);
            LoginViewModel = new LoginViewModel(this.AuthService);
            PasswordListViewModel = new PasswordListViewModel(this.PasswordModel);

            // Views
            RegisterView = new Register(this.RegisterViewModel);
            LoginView = new Login(this.LoginViewModel);
            PasswordList = new PasswordList(this.PasswordListViewModel);

            // Events for navigation
            LoginViewModel.OnNavigate += Navigate;
        }

        // It allows to open or close the views.
        public void Navigate(string view)
        {
            switch(view)
            {
                case "Login":
                    this.LoginView.Show();
                    break;

                case "Register":
                    this.RegisterView.Show();
                    break;

                case "PasswordList":
                    this.PasswordList.Show();
                    break;
            }
        }

        // It allows to close a view.
        public void Close(string view)
        {
            switch (view)
            {
                case "Login":
                    this.LoginView.Hide();
                    break;

                case "Register":
                    this.RegisterView.Close();
                    break;

                case "PasswordList":
                    this.PasswordList.Close();
                    break;
            }
        }
    }
}
