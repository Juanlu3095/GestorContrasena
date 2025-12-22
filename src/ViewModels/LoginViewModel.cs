using GestorContrasena.Contracts.Entities.User;
using GestorContrasena.Contracts.Exceptions;
using GestorContrasena.Contracts.Interfaces;
using GestorContrasena.Schemas;
using Npgsql;

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
                try
                {
                    var login = this.authService.Login(user); // Hacer un try/catch aquí con excepción personalizada cuando no se encuentre el usuario por email
                    if (login)
                    {
                        MessageBox.Show("Inicio de sesión realizado correctamente.", "Inicio de sesión correcto");
                    }
                    else
                    {
                        MessageBox.Show("Credenciales incorrectas.", "Error en el inicio de sesión");
                    }

                } catch (InvalidCredentialsException e)
                {
                    MessageBox.Show(e.Message, "Error en el inicio de sesión");
                } catch (NpgsqlException)
                {
                    MessageBox.Show("Servicio no disponible. Por favor, contacte con su técnico.", "Servicio no disponible");
                }
            }
        }

        public void ToRegister()
        {
            this.OnNavigate?.Invoke("Register");
        }
    }
}
