
using GestorContrasena.Contracts.Entities.Password;
using GestorContrasena.Contracts.Exceptions;
using GestorContrasena.Contracts.Interfaces;
using GestorContrasena.Schemas;

namespace GestorContrasena.ViewModels
{
    internal class PasswordCreateViewModel : PasswordCreateViewModelInterface
    {
        private readonly PasswordModelInterface PasswordModel;

        public PasswordCreateViewModel(PasswordModelInterface PasswordModel)
        {
            this.PasswordModel = PasswordModel;
        }

        public void AddPasswordAction(string name, string value, string service, string observations)
        {
            PasswordInput password = new() // No se está usando el constructor
            {
                Name = name,
                Value = value,
                Service = service,
                Observations = observations
            };

            var validation = PasswordSchema.PasswordInputValidation(password);

            if (!validation.success)
            {
                string errors = "";
                foreach (KeyValuePair<string, string> error in validation.GetErrors())
                {
                    errors += error.Value + "\n";
                }
                MessageBox.Show("Error(es) en la creación del nuevo elemento: \n" + errors, "Error al crear elemento");
            } else
            {
                try
                {
                    var resultCreatePassword = this.PasswordModel.Create(password);
                    if (resultCreatePassword > 0)
                    {
                        MessageBox.Show("Elemento creado correctamente.", "Nuevo elemento creado correctamente");
                    }
                } catch (ResourceNotCreatedException)
                {
                    MessageBox.Show("Error al crear el nuevo elemento. Contacte con su técnico.", "Error al crear nuevo elemento");
                }
            }
        }
    }
}
