
namespace GestorContrasena.Contracts.Interfaces
{
    public interface LoginViewModelInterface
    {
        public void LoginAction(string email, string password);

        public void ToRegister();
    }
}
