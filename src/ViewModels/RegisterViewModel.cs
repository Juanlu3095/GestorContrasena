using GestorContrasena.Contracts.Entities;
using GestorContrasena.Contracts.Interfaces;

namespace GestorContrasena.ViewModels
{
    internal class RegisterViewModel : RegisterViewModelInterface
    {
        private readonly AuthModelInterface AuthModel; 

        public event Action<string>? OnNavigate;

        public RegisterViewModel (AuthModelInterface AuthModel)
        {
            this.AuthModel = AuthModel;
        }

        public void RegisterAction (string name, string email, string password)
        {
            UserEntity user = new UserEntity();
            user.Name = name;
            user.Email = email;
            user.Password = password;

            this.AuthModel.Register(user);
        }

        public void ToLogin()
        {
            this.OnNavigate?.Invoke("InicioSesion");
        }
    }
}
