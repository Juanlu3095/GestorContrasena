using System.Text.RegularExpressions;

namespace GestorContrasena.Utilities
{
    internal class CustomValidations
    {
        public static bool ValidateEmail (string email)
        {
            var trimmedEmail = email.Trim();

            string correctPattern = "^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$";

            if (string.IsNullOrEmpty(trimmedEmail))
            {
                return false;
            }

            Regex regex = new Regex(correctPattern);

            return regex.IsMatch(trimmedEmail);
        }
    }
}
