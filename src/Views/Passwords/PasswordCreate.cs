
using GestorContrasena.Contracts.Interfaces;

namespace GestorContrasena.Views.Passwords
{
    public partial class PasswordCreateForm : Form
    {
        internal PasswordCreateViewModelInterface PasswordCreateViewModel;

        internal PasswordCreateForm(PasswordCreateViewModelInterface PasswordCreateViewModel)
        {
            InitializeComponent();
            this.PasswordCreateViewModel = PasswordCreateViewModel;
        }

        public void CreatePasswordAction(object sender, EventArgs e)
        {
            this.PasswordCreateViewModel.AddPasswordAction(this.NameInput.Text, this.ValueInput.Text, this.ServiceInput.Text, this.ObservationsInput.Text);
        }
    }
}
