
using GestorContrasena.Contracts.Entities.Password;

namespace GestorContrasena.Contracts.Interfaces
{
    internal interface PasswordListViewModelInterface
    {
        public List<PasswordEntity>? GetAllPasswords();
        public void ToPasswordCreate();
        public void ToLogin(object sender, FormClosedEventArgs e);
    }
}
