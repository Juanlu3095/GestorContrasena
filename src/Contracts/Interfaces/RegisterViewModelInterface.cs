

namespace GestorContrasena.Contracts.Interfaces
{
    public interface RegisterViewModelInterface
    {
        public void ToLogin();

        public void RegisterAction(string name, string email, string password);
    }
}
