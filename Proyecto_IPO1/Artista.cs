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
        public string Integrates { set; get; }
        public string Genero { set; get; }
        public Uri Redes_sociales { set; get; }  
        public string Descripción { set; get; }
        


        public Artista(string nombre, String integrates,
        String genero, Uri redes_sociales, string descripción)
        {
            Nombre = nombre;
            Integrates = integrates;
            Genero = genero;
            Redes_sociales = redes_sociales;
            Descripción = descripción;
        }
    }
}
