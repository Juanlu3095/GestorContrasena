using GestorContrasena.Contracts.Interfaces;

namespace GestorContrasena.Views
{
    public partial class Login : Form
    {
        public LoginViewModelInterface LoginViewModel;

        public Login(LoginViewModelInterface LoginViewModel)
        {
            this.LoginViewModel = LoginViewModel;
            InitializeComponent();
        }

        /// <summary>
        /// It sends the new user input to database to create it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LoginAction(object sender, EventArgs e)
        {
            this.LoginViewModel.LoginAction(this.EmailInput.Text, this.PasswordInput.Text);
        }

        public void ToRegisterAction(object sender, EventArgs e)
        {
            this.LoginViewModel.ToRegister();
        }
    }
}
