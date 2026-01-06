
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


    }
}
