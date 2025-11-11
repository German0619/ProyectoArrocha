using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoArrocha
{
    public static class Session
    {
        public static int IdUsuario { get; set; } = 0;
        public static string Correo { get; set; } = string.Empty;
        public static string Nombre { get; set; } = string.Empty;

        public static bool IsLogged => !string.IsNullOrEmpty(Correo);
    }
}
