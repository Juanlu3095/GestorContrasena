
namespace GestorContrasena.Contracts.Exceptions
{
    internal class ResourceNotDeletedException : Exception
    {
        internal ResourceNotDeletedException(string errorMessage) : base(errorMessage) { }
    }
}
