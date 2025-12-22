
namespace GestorContrasena.Contracts.Exceptions
{
    internal class ResourceNotFoundException : Exception // Hereda de Exception
    {
        public ResourceNotFoundException(string errorMessage) : base(errorMessage) // En este constructor se pasa directamente el mensaje de error al consctructor del padre
        {
            
        }
    }
}
