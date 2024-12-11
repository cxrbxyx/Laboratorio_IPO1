using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_IPO1
{
    internal class Festival
    {

        public string Nombre { set; get; }
        public List<String>  Fechas { set; get; }
        public List<Artista> Artistas { set; get; }
        public Uri Redes_sociales { set; get; }
        public List<String> Precios { set; get; }
        public Uri Caratula { set; get; }
        public string Estado { set; get; }

        public Uri Cartelera { set; get; }
        public string Descripcion { set; get; }

        public Festival(string nombre, List<String> fechas, List<Artista> artistas, Uri redes_sociales, List<string> precios, Uri caratula, string estado, Uri cartelera, string descripcion)
        {
            Nombre = nombre;
            Fechas = fechas;
            Artistas = artistas;
            Redes_sociales = redes_sociales;
            Precios = precios;
            Caratula = caratula;
            Estado = estado;
            Cartelera = cartelera;
            Descripcion = descripcion;
        }

    }
}
