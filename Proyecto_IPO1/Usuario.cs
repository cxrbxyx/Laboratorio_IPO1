using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_IPO1
{
    public class Usuario
    {
        public String NombreUsuario { get; set; }
        
        public String Contrasena { get; set; }

        public Usuario(string nombreUsuario, string contrasena)
        {
            NombreUsuario = nombreUsuario ?? throw new ArgumentNullException(nameof(nombreUsuario));
            Contrasena = contrasena ?? throw new ArgumentNullException(nameof(contrasena));
        }
    }
}
