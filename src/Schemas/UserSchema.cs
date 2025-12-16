using GestorContrasena.Contracts.Entities;
using GestorContrasena.Utilities;

namespace GestorContrasena.Schemas
{
    internal class UserSchema
    {
        public static UserRegisterValidation UserRegisterValidation (UserEntity user)
        {
            UserRegisterValidation result = new UserRegisterValidation();

            result.success = true;
            
            if (String.IsNullOrWhiteSpace(user.Name))
            {
                result.success = false;
                result.setErrorName("El campo nombre no tiene un formato correcto.");
            }

            if (!CustomValidations.ValidateEmail(user.Email))
            {
                result.success = false;
                result.setErrorEmail("El campo email no tiene un formato correcto.");
            }

            if (String.IsNullOrWhiteSpace(user.Password))
            {
                result.success = false;
                result.setErrorPassword("El campo contraseña no tiene un formato correcto.");
            }

            return result;
        }

    }
}
