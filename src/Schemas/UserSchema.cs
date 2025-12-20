using GestorContrasena.Contracts.Entities;
using GestorContrasena.Utilities;

namespace GestorContrasena.Schemas
{
    internal class UserSchema
    {
        public static UserRegisterValidation UserRegisterValidation (UserEntity user, string repeat_password)
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

            if (String.IsNullOrWhiteSpace(repeat_password) || repeat_password != user.Password)
            {
                result.success = false;
                result.setErrorRepeatPassword("El campo repetir contraseña no tiene un formato correcto o no coincide con el campo contraseña.");
            }

            return result;
        }

        public static UserLoginValidation UserLoginValidation(UserEntity user)
        {
            UserLoginValidation result = new UserLoginValidation();

            result.success = true;

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
