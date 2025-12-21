namespace GestorContrasena.Contracts.Entities.User
{
    internal class UserLoginValidationResult
    {
        public bool success { get; set; }

        public Dictionary<string, string> errors = new Dictionary<string, string>();

        public Dictionary<string, string> GetErrors()
        {
            return errors;
        }

        public void setErrorEmail(string errorEmail)
        {
            errors["email"] = errorEmail;
        }

        public void setErrorPassword(string errorPassword)
        {
            errors["password"] = errorPassword;
        }
    }
}
