using GestorContrasena.Contracts.Interfaces;

namespace GestorContrasena.Views.Passwords
{
    public partial class PasswordList : Form
    {
        private PasswordListViewModelInterface PasswordListViewModel;
        public PasswordList(PasswordListViewModelInterface PasswordListViewModel)
        {
            this.PasswordListViewModel = PasswordListViewModel;
            InitializeComponent();
        }
    }
}
