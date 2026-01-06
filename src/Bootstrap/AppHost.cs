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
        private PasswordCreateViewModel PasswordCreateViewModel;
        public Register RegisterView;
        public Login LoginView;
        public PasswordList PasswordListView;
        public PasswordCreate PasswordCreateView;

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
            PasswordCreateViewModel = new PasswordCreateViewModel(this.PasswordModel);

            // Views
            RegisterView = new Register(this.RegisterViewModel);
            LoginView = new Login(this.LoginViewModel);
            PasswordListView = new PasswordList(this.PasswordListViewModel);
            PasswordCreateView = new PasswordCreate(this.PasswordCreateViewModel);

            // Events for navigation
            LoginViewModel.OnNavigate += Navigate;
            PasswordListViewModel.OnNavigate += Navigate;

            // Events to close views
            LoginViewModel.OnClose += Close;
            
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
                    if (RegisterView.IsDisposed) this.RegisterView = new Register(this.RegisterViewModel);
                    this.RegisterView.Show();
                    break;

                case "PasswordList":
                    if (PasswordListView.IsDisposed) this.PasswordListView = new PasswordList(this.PasswordListViewModel);// Si se cierra el form dará un error de que se ha eliminado el form
                    this.PasswordListView.Show();
                    break;

                case "PasswordCreate":
                    if (PasswordCreateView.IsDisposed) this.PasswordCreateView = new PasswordCreate(this.PasswordCreateViewModel);
                    this.PasswordCreateView.Show();
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
                    this.PasswordListView.Close();
                    break;
            }
        }
    }
}
