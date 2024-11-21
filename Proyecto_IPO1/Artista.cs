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
        public string Anio { set; get; }
        public string Integrates { set; get; }
        public string Genero { set; get; }
        public Uri Caratula { set; get; }
        public List<string> reparto = new List<string>();
        public string Argumento { set; get; }
    

    public Artista(string nombre, string anio, String integrates,
    String genero, Uri caratula, string argumento)
    {
        Nombre = nombre;
        Anio = anio;
        Integrates = integrates;
        Genero = genero;
        Caratula = caratula;
        Argumento = argumento;
    }
}
