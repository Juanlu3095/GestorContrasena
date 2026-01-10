using GestorContrasena.Contracts.Entities.Password;
using GestorContrasena.Contracts.Exceptions;
using GestorContrasena.Contracts.Interfaces;
using GestorContrasena.Schemas;

namespace GestorContrasena.ViewModels
{
    internal class PasswordEditViewModel : PasswordEditViewModelInterface // Los métodos a implementar de la interfaz tendrán que ser siempre públicos, las interfaces exponen métodos
    {
        private PasswordModelInterface PasswordModel;

        internal PasswordEditViewModel(PasswordModelInterface PasswordModel)
        {
            this.PasswordModel = PasswordModel;
        }

        public PasswordEntity GetPassword(Guid id)
        {
            try
            {
                return this.PasswordModel.GetById(id) ?? new PasswordEntity();
            } catch (ResourceNotFoundException)
            {
                MessageBox.Show("El registro a editar no se ha encontrado.", "Error al obtener la contraseña");
                return new PasswordEntity();
            }

        }

        public void EditPassword (Guid id, string name, string value, string service, string observations)
        {
            PasswordInput PasswordInput = new()
            {
                Name = name,
                Value = value,
                Service = service,
                Observations = observations
            };

            var PasswordValidation = PasswordSchema.PasswordInputValidation(PasswordInput);
            if (PasswordValidation.success)
            {
                try
                {
                    var result = this.PasswordModel.Update(id, PasswordInput);
                    if (result == 1)
                    {
                        MessageBox.Show("Contraseña editada correctamente.", "Contraseña editada");
                    } 
                }
                catch (ResourceNotFoundException)
                {
                    MessageBox.Show("El registro a editar no se ha encontrado.", "Error al editar contraseña");
                }
            } else
            {
                string errors = "";
                foreach (KeyValuePair<string, string> error in PasswordValidation.GetErrors())
                {
                    errors += error.Value + "\n";
                }
                MessageBox.Show("Error(es) al editar la contraseña: \n" + errors, "Error al editar contraseña");
            }
        }
    }
}
