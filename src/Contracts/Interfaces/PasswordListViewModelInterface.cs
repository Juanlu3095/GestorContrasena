
using GestorContrasena.Contracts.Entities.Password;

namespace GestorContrasena.Contracts.Interfaces
{
    internal interface PasswordListViewModelInterface
    {
        public List<PasswordEntity>? GetAllPasswords();
        public void ToPasswordCreate();
        public List<PasswordEntity>? FilterPasswordsByName(string name);
        public void ToPasswordEdit(Guid id);
        public void DeletePassword(Guid id);
        public void ToLogin(object sender, FormClosedEventArgs e);
    }
}
