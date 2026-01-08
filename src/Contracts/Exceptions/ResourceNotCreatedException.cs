
namespace GestorContrasena.Contracts.Exceptions
{
    internal class ResourceNotCreatedException : Exception
    {
        internal ResourceNotCreatedException(string errorMessage) : base(errorMessage) // En este constructor se pasa directamente el mensaje de error al consctructor del padre
        {

        }
    }
}
