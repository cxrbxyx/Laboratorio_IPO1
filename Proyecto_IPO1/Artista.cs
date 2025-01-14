using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto_IPO1
{
    public class Artista
    {
        public string Nombre { set; get; }
        public string Integrantes { set; get; }
        public string Genero { set; get; }
        public Uri Redes_sociales { set; get; }  
        public string Descripcion { set; get; }
        public Uri Caratula { set; get; }

        public string Contacto { set; get; }    

        public string Estado { set; get; }
        public List<string> Festivales { set; get; }


        public Artista(string nombre, string integrantes,
        string genero, Uri redes_sociales, string descripcion , Uri caratula, string contacto, string estado, List<string> festivales)
        {
            Nombre = nombre;
            Integrantes = integrantes;
            Genero = genero;
            Redes_sociales = redes_sociales;
            Descripcion = descripcion;
            Caratula = caratula;
            Contacto = contacto;
            Estado = estado;
            Festivales = festivales;
        }
    }
}
