

namespace GestorContrasena.Contracts.Exceptions
{
    internal class EmailAlreadyExistsException : Exception
    {
        internal EmailAlreadyExistsException(string mensaje) : base(mensaje) { }
        internal EmailAlreadyExistsException(string mensaje, Exception innerException) : base(mensaje, innerException) { }
    }
}
