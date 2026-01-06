

using GestorContrasena.Contracts.Entities.Password;
using GestorContrasena.Contracts.Interfaces;
using Npgsql;

namespace GestorContrasena.ViewModels
{
    internal class PasswordListViewModel : PasswordListViewModelInterface
    {
        private PasswordModelInterface PasswordModel;
        public event Action<string>? OnNavigate;

        public PasswordListViewModel(PasswordModelInterface PasswordModel)
        {
            this.PasswordModel = PasswordModel;
        }

        public List<PasswordEntity>? GetAllPasswords()
        {
            try
            {
                return this.PasswordModel.GetAll();
            } catch (NpgsqlException)
            {
                MessageBox.Show("Ha ocurrido un error al obtener las contraseñas.", "Error del sistema");
                return null;
            }
        }

        public void ToPasswordCreate()
        {
            this.OnNavigate?.Invoke("PasswordCreate");
        }

        public void ToLogin(object sender, FormClosedEventArgs e)
        {
            this.OnNavigate?.Invoke("Login");
        }
    }
}
