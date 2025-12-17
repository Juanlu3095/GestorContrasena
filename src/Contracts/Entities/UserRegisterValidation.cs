

namespace GestorContrasena.Contracts.Entities
{
    internal class UserRegisterValidation
    {
        public bool success { get; set; }

        public Dictionary<string, string> errors = new Dictionary<string, string>();

        public Dictionary<string, string> GetErrors ()
        {
            return this.errors;
        }

        public void setErrorName (string errorName)
        {
            this.errors["nombre"] = errorName;
        }

        public void setErrorEmail (string errorEmail)
        {
            this.errors["email"] = errorEmail;
        }

        public void setErrorPassword (string errorPassword)
        {
            this.errors["password"] = errorPassword;
        }

    }
}
