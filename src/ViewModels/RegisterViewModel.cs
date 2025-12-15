using GestorContrasena.Contracts.Entities;
using GestorContrasena.Contracts.Interfaces;
using GestorContrasena.Schemas;

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
                var result = this.AuthModel.Register(user);
                if (result != null)
                {
                    MessageBox.Show("Registro realizado correctamente.", "Registro correcto");
                }
                else
                {
                    MessageBox.Show("No se ha podido realizar el registro. Consulte con su técnico.", "Error en el registro");
                }
            }
        }

        public void ToLogin()
        {
            this.OnNavigate?.Invoke("InicioSesion");
        }
    }
}
