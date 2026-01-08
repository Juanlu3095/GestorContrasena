
namespace GestorContrasena.Contracts.Exceptions
{
    internal class InvalidCredentialsException : Exception
    {
        internal InvalidCredentialsException(string message) : base(message) { }
    }
}
