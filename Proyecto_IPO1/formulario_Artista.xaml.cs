using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace Proyecto_IPO1
{
    /// <summary>
    /// Lógica de interacción para formulario_Artista.xaml
    /// </summary>
    public partial class formulario_Artista : Window
    {
        List<Artista> lista_artistas; 

        public formulario_Artista()
        {
            InitializeComponent();

            lista_artistas = new List<Artista>();

            lista_artistas = CargarContenidoXML();

            lstListaArtistas.ItemsSource = lista_artistas;
        }

        private List<Artista> CargarContenidoXML()
        {
            List<Artista> listado = new List<Artista>();
            // Cargar contenido de prueba
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("database/artistas.xml", UriKind.Relative)); doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevaArtista = new Artista("", "", "", null, "",null);
                nuevaArtista.Nombre = node.Attributes["Nombre"].Value;
                nuevaArtista.Integrates = node.Attributes["Integrates"].Value;
                nuevaArtista.Genero = node.Attributes["Genero"].Value;
                nuevaArtista.Redes_sociales = new Uri(node.Attributes["Redes_sociales"].Value, UriKind.Relative);
                nuevaArtista.Descripción = node.Attributes["Descripción"].Value;
                nuevaArtista.Caratula = new Uri(node.Attributes["Caratula"].Value, UriKind.Relative);

                listado.Add(nuevaArtista);
            }
            return listado;
        }
    }
}
