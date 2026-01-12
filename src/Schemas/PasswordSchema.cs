
using GestorContrasena.Contracts.Entities.Password;

namespace GestorContrasena.Schemas
{
    internal class PasswordSchema
    {
        public static PasswordInputValidationResult PasswordInputValidation(PasswordInput password)
        {
            PasswordInputValidationResult result = new();

            result.success = true;

            if (String.IsNullOrWhiteSpace(password.Name))
            {
                result.success = false;
                result.setErrorName("El campo nombre no tiene un formato correcto.");
            }

            if (String.IsNullOrWhiteSpace(password.Value))
            {
                result.success = false;
                result.setErrorValue("El campo valor no tiene un formato correcto.");
            }

            if (String.IsNullOrWhiteSpace(password.Service))
            {
                result.success = false;
                result.setErrorService("El campo servicio no tiene un formato correcto.");
            }

            if (password.Observations == null)
            {
                result.success = false;
                result.setErrorObservations("El campo observaciones no tiene un formato correcto.");
            }

            return result;
        }
    }
}
