
namespace GestorContrasena.Contracts.Exceptions
{
    internal class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException(string message) : base(message) { }
    }
}
