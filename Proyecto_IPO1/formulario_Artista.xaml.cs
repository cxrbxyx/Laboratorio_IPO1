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

        public formulario_Artista()
        {
            InitializeComponent();
            try
            {
                List<Artista> lista_artistas = new List<Artista>();
                lista_artistas = CargarContenidoXML();
                lstListaArtistas.ItemsSource = lista_artistas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los artistas: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private List<Artista> CargarContenidoXML()
        {
            List<Artista> listado = new List<Artista>();
            XmlDocument database = new XmlDocument();
                var fichero = Application.GetResourceStream(new Uri("database/artistas.xml", UriKind.Relative));
                database.Load(fichero.Stream);

                foreach (XmlNode node in database.DocumentElement.ChildNodes)
                {
                    var artista = new Artista("", "", "", null, "", null,"")
                    {
                        Nombre = node.Attributes["Nombre"].Value,
                        Integrantes = node.Attributes["Integrantes"].Value,
                        Genero = node.Attributes["Genero"].Value,
                        Redes_sociales = new Uri(node.Attributes["Redes_sociales"].Value, UriKind.Absolute),
                        Descripcion = node.Attributes["Descripcion"].Value,
                        Caratula = new Uri(node.Attributes["Caratula"].Value, UriKind.Relative),
                        Festivales = node.Attributes["Festivales"].Value
                    };
                    listado.Add(artista);

                }
                return listado;
        }
    }
}
