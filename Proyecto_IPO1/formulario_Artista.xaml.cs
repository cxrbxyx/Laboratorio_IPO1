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
            try
            {
                lista_artistas = new List<Artista>();

                lista_artistas = CargarContenidoXML();
                MessageBox.Show("Error al cargar los artistas: " + lista_artistas);
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
            // Cargar contenido de prueba
            var fichero = Application.GetResourceStream(new Uri("database/artistas.xml", UriKind.Relative));
            if (fichero == null)
            {
                MessageBox.Show("No se pudo cargar el archivo XML. Verifica su ubicación y configuración.",
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return listado;
            }
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("database/artistas.xml", UriKind.Relative)); doc.Load(fichero.Stream);
            if (fichero == null)
            {
                MessageBox.Show("No se pudo cargar el archivo 'artistas.xml'. Verifica su existencia y configuración.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return new List<Artista>(); // Devuelve una lista vacía para evitar que la aplicación falle.
            }
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                // Crear una instancia vacía del objeto Artista
                var nuevaArtista = new Artista("", "", "", null, "", null);
                
                // Verificar y asignar valores de los atributos de manera segura
                if (node.Attributes["Nombre"] != null)
                    nuevaArtista.Nombre = node.Attributes["Nombre"].Value;

                if (node.Attributes["Integrates"] != null)
                    nuevaArtista.Integrates = node.Attributes["Integrates"].Value;

                if (node.Attributes["Genero"] != null)
                    nuevaArtista.Genero = node.Attributes["Genero"].Value;

                if (node.Attributes["Redes_sociales"] != null)
                    nuevaArtista.Redes_sociales = new Uri(node.Attributes["Redes_sociales"].Value, UriKind.Relative);

                if (node.Attributes["Descripción"] != null)
                    nuevaArtista.Descripción = node.Attributes["Descripción"].Value;

                if (node.Attributes["Caratula"] != null)
                    nuevaArtista.Caratula = new Uri(node.Attributes["Caratula"].Value, UriKind.Relative);

                listado.Add(nuevaArtista);
            }
            return listado;
        }
    }
}
