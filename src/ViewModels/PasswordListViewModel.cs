

using GestorContrasena.Contracts.Interfaces;

namespace GestorContrasena.ViewModels
{
    internal class PasswordListViewModel : PasswordListViewModelInterface
    {
        private PasswordModelInterface PasswordModel;
        public PasswordListViewModel(PasswordModelInterface PasswordModel)
        {
            this.PasswordModel = PasswordModel;
        }
    }
}
