﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_IPO1
{
    public class Festival
    {

        public string Nombre { set; get; }
        public List<String>  Fechas { set; get; }
        public List<Artista> Artistas { set; get; }
        public string Redes_sociales { set; get; }
        public List<String> Precios { set; get; }
        public Uri Caratula { set; get; }
        public string Estado { set; get; }

        public Uri Cartelera { set; get; }
        public string Descripcion { set; get; }

        public string Contacto { set; get; }
        public string Genero { set; get; }

        public Festival(string nombre, List<String> fechas, List<Artista> artistas, string redes_sociales, List<string> precios, Uri caratula, string estado, Uri cartelera, string descripcion, string genero)
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
            Genero = genero;
        }

    }
}
