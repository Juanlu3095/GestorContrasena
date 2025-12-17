

namespace GestorContrasena.Contracts.Exceptions
{
    internal class EmailAlreadyExistsException : Exception
    {
        public EmailAlreadyExistsException(string mensaje) : base(mensaje) { }
        public EmailAlreadyExistsException(string mensaje, Exception innerException) : base(mensaje, innerException) { }
    }
}
