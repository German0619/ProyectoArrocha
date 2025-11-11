using System.Windows.Forms;

namespace ProyectoArrocha
{
    public static class Session
    {
        public static int IdUsuario { get; private set; }
        public static string Nombre { get; private set; }
        public static string Correo { get; private set; }

        public static bool IsLoggedIn => !string.IsNullOrEmpty(Correo);
        public static void IniciarSesion(int idUsuario, string nombre, string correo)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Correo = correo;
        }

        public static void CerrarSesion()
        {
            IdUsuario = 0;
            Nombre = null;
            Correo = null;
        }
    }
}
