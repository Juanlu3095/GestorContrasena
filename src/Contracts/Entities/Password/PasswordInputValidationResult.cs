
namespace GestorContrasena.Contracts.Entities.Password
{
    internal class PasswordInputValidationResult
    {
        public bool success { get; set; }

        public Dictionary<string, string> errors = new Dictionary<string, string>();

        public Dictionary<string, string> GetErrors()
        {
            return errors;
        }

        public void setErrorName(string errorName)
        {
            errors["name"] = errorName;
        }

        public void setErrorValue(string errorValue)
        {
            errors["value"] = errorValue;
        }

        public void setErrorService(string errorService)
        {
            errors["service"] = errorService;
        }

        public void setErrorObservations(string errorObservations)
        {
            errors["observations"] = errorObservations;
        }
    }
}
