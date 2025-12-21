using GestorContrasena.Contracts.Entities.User;
using GestorContrasena.Contracts.Interfaces;
using GestorContrasena.Schemas;

namespace GestorContrasena.ViewModels
{
    internal class LoginViewModel(AuthServiceInterface authService) : LoginViewModelInterface // Constructor nuevo compatible con c# versión 12 en adelante
    {
        private readonly AuthServiceInterface authService = authService;
        public event Action<string>? OnNavigate;

        public void LoginAction(string email, string password)
        {
            UserLoginInput user = new UserLoginInput();
            user.Email = email;
            user.Password = password;

            UserLoginValidationResult validation = UserSchema.UserLoginValidation(user);

            if (!validation.success)
            {
                string errors = "";
                foreach (KeyValuePair<string, string> error in validation.GetErrors())
                {
                    errors += error.Value + "\n";
                }
                MessageBox.Show("Error(es) en el formulario de inicio de sesión: \n" + errors, "Error en el inicio de sesión");

            } else
            {
                var login = this.authService.Login(user); // Hacer un try/catch aquí con excepción personalizada cuando no se encuentre el usuario por email
                if (login != null && login == true)
                {
                    MessageBox.Show("Inicio de sesión realizado correctamente.", "Inicio de sesión correcto");
                } else
                {
                    MessageBox.Show("No se ha podido realizar el inicio de sesión. Consulte con su técnico.", "Error en el inicio de sesión");
                }
            }
        }

        public void ToRegister()
        {
            this.OnNavigate?.Invoke("Register");
        }
    }
}
