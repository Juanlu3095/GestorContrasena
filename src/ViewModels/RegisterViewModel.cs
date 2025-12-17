using GestorContrasena.Contracts.Entities;
using GestorContrasena.Contracts.Exceptions;
using GestorContrasena.Contracts.Interfaces;
using GestorContrasena.Schemas;

namespace GestorContrasena.ViewModels
{
    internal class RegisterViewModel : RegisterViewModelInterface
    {
        private readonly AuthServiceInterface authService; 

        public event Action<string>? OnNavigate;

        public RegisterViewModel (AuthServiceInterface authService)
        {
            this.authService = authService;
        }

        public void RegisterAction (string name, string email, string password)
        {
            UserEntity user = new UserEntity();
            user.Name = name;
            user.Email = email;
            user.Password = password;

            UserRegisterValidation validation = UserSchema.UserRegisterValidation(user);

            if (!validation.success)
            {
                string errors = "";
                foreach (KeyValuePair<string, string> error in validation.GetErrors())
                {
                    errors += error.Value + "\n";
                }
                MessageBox.Show("Error(es) en el formulario de registro: \n" + errors, "Error en el registro");

            } else
            {
                try
                {
                    var result = this.authService.Register(user);

                    if (result != null)
                    {
                        MessageBox.Show("Registro realizado correctamente.", "Registro correcto");
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido realizar el registro. Consulte con su técnico.", "Error en el registro");
                    }

                } catch (EmailAlreadyExistsException e)
                {
                    MessageBox.Show(e.Message, "Error en el registro");
                }
                
            }
        }

        public void ToLogin()
        {
            this.OnNavigate?.Invoke("InicioSesion");
        }
    }
}
