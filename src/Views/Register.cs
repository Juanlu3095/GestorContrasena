using GestorContrasena.Contracts.Interfaces;

namespace GestorContrasena.Views
{
    public partial class Register : Form
    {
        public RegisterViewModelInterface RegisterViewModel;

        public Register(RegisterViewModelInterface RegisterViewModel)
        {
            this.RegisterViewModel = RegisterViewModel;
            InitializeComponent();
        }

        /// <summary>
        /// It sends the new user input to database to create it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegisterAction(object sender, EventArgs e)
        {
            this.RegisterViewModel.RegisterAction(this.NameInput.Text, this.EmailInput.Text, this.PasswordInput.Text, this.RepeatPasswordInput.Text);
        }
    }
}
