
using GestorContrasena.Contracts.Entities.Password;
using GestorContrasena.Contracts.Interfaces;

namespace GestorContrasena.Views.Passwords
{
    internal partial class PasswordEdit : Form // La clase nunca debe exponer tipos más accesibles que ella, esto aplica a atributos, métodos, etc
    {
        private readonly PasswordEditViewModelInterface PasswordEditViewModel;
        private readonly Guid Id;
        internal PasswordEdit(PasswordEditViewModelInterface PasswordEditViewModel, Guid Id) // EL CONTRUCTOR NO DEBE NUNCA SER MÁS ACCESIBLE QUE SUS PARÁMETROS, por eso debe ser internal
        {
            InitializeComponent();
            this.Id = Id;
            this.PasswordEditViewModel = PasswordEditViewModel;
            this.ShowPasswordInForm();
        }

        internal void ShowPasswordInForm()
        {
            PasswordEntity Password = this.PasswordEditViewModel.GetPassword(this.Id);
            this.NameInput.Text = Password.Name;
            this.ValueInput.Text = Password.Value;
            this.ServiceInput.Text = Password.Service;
            this.ObservationsInput.Text = Password.Observations;
        }

        public void EditPassword(object sender, EventArgs e)
        {
            this.PasswordEditViewModel.EditPassword(this.Id, this.NameInput.Text, this.ValueInput.Text, this.ServiceInput.Text, this.ObservationsInput.Text);
        }
    }
}
