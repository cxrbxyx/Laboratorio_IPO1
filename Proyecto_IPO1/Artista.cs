using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto_IPO1
{
    class Artista
    {
        public string Nombre { set; get; }
        public string Integrantes { set; get; }
        public string Genero { set; get; }
        public Uri Redes_sociales { set; get; }  
        public string Descripcion { set; get; }
        public Uri Caratula { set; get; }



        public Artista(string nombre, String integrantes,
        String genero, Uri redes_sociales, string descripcion , Uri caratula)
        {
            Nombre = nombre;
            Integrantes = integrantes;
            Genero = genero;
            Redes_sociales = redes_sociales;
            Descripcion = descripcion;
            Caratula = caratula;
        }
    }
}
