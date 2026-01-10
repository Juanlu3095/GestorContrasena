
using GestorContrasena.Contracts.Interfaces;

namespace GestorContrasena.Views.Passwords
{
    public partial class PasswordCreate : Form
    {
        internal PasswordCreateViewModelInterface PasswordCreateViewModel;

        internal PasswordCreate(PasswordCreateViewModelInterface PasswordCreateViewModel)
        {
            InitializeComponent();
            this.PasswordCreateViewModel = PasswordCreateViewModel;
        }

        public void CreatePasswordAction(object sender, EventArgs e)
        {
            var CreateResult = this.PasswordCreateViewModel.AddPasswordAction(this.NameInput.Text, this.ValueInput.Text, this.ServiceInput.Text, this.ObservationsInput.Text);
            if (CreateResult)
            {
                this.NameInput.ResetText();
                this.ValueInput.ResetText();
                this.ServiceInput.ResetText();
                this.ObservationsInput.ResetText();
            }
        }
    }
}
