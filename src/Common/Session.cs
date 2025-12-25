
namespace GestorContrasena.Common
{
    // Clase static porque sólo se va a tener una sesión a la vez. En los tests tampoco habrá problema si se cierra la sesión o se finalizan los tests antes de iniciar más
    // que dependan de la sesión
    internal static class Session
    {
        public static Guid? Id { get; private set; } 
        public static string? Name { get; private set; } 
        public static string? Email { get; private set; } 

        public static bool IsAuthenticated()
        {
            return Id != null;
        }

        public static void Initialize (Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public static void End ()
        {
            Id = null;
            Name = null;
            Email = null;
        }
    }
}
