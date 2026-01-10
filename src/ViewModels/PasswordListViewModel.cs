

using GestorContrasena.Contracts.Entities.Password;
using GestorContrasena.Contracts.Exceptions;
using GestorContrasena.Contracts.Interfaces;
using Npgsql;

namespace GestorContrasena.ViewModels
{
    internal class PasswordListViewModel : PasswordListViewModelInterface
    {
        private PasswordModelInterface PasswordModel;
        public event Action<string>? OnNavigate;
        public event Action<object[]>? OnDynamicNavigate;

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

        public List<PasswordEntity>? FilterPasswordsByName(string name)
        {
            try
            {
                return this.PasswordModel.GetByName(name);
            } catch (ResourceNotFoundException)
            {
                MessageBox.Show("No se ha encontrado ningún registro por el término '" + name + "'.", "Elemento no encontrado");
                return null;
            }
        }

        public void ToPasswordEdit(Guid id)
        {
            Object[] args = { "PasswordEdit", id };
            this.OnDynamicNavigate?.Invoke(args);
        }

        public void DeletePassword(Guid id)
        {
            try
            {
                var result = this.PasswordModel.Delete(id);
                if (result > 0)
                {
                    MessageBox.Show("Contraseña eliminada correctamente.", "Elemento eliminado");
                }
                else
                {
                    MessageBox.Show("Servicio no disponible.", "Elemento no eliminado");
                }
            } catch (ResourceNotDeletedException)
            {
                MessageBox.Show("Ha ocurrido un error al eliminar el elemento.", "Elemento no eliminado");
            }
            
        }

        public void ToLogin(object sender, FormClosedEventArgs e)
        {
            this.OnNavigate?.Invoke("Login");
        }
    }
}
