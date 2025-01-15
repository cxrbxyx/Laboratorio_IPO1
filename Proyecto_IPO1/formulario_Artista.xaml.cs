using System;
using System.Collections.Generic;
using System.Globalization;
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
        private Ventana_guardar ventana;
        private Artista ArtistaActual;
        private Ventana_guardar ventanaGuardar;
        private Artista ArtistaGuardar;
        public formulario_Artista(Festival festival)
        {
            InitializeComponent();
            try
            {
                List<Artista> lista_artistas = new List<Artista>();
                lista_artistas = CargarContenidoXML(festival);
                lstListaArtistas.ItemsSource = lista_artistas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los artistas: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private List<Artista> CargarContenidoXML(Festival festival)
        {
            List<Artista> listado = new List<Artista>();
            XmlDocument database = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("database/artistas.xml", UriKind.Relative));
            database.Load(fichero.Stream);

            foreach (XmlNode node in database.DocumentElement.ChildNodes)
            {
                var artista = new Artista("", "", "", null, "", null, "", "", null)
                {
                    Nombre = node.Attributes["Nombre"].Value,
                    Integrantes = node.Attributes["Integrantes"].Value,
                    Genero = node.Attributes["Genero"].Value,
                    Redes_sociales = new Uri(node.Attributes["Redes_sociales"].Value, UriKind.Absolute),
                    Descripcion = node.Attributes["Descripcion"].Value,
                    Caratula = new Uri(node.Attributes["Caratula"].Value, UriKind.Relative),
                    Contacto = node.Attributes["Contacto"].Value,
                    Estado = node.Attributes["Estado"].Value,
                    Festivales = new List<string>(),
                };

                if (festival.Artistas.Any(a => a.Nombre == artista.Nombre))
                {
                    artista.Festivales.Add(festival.Nombre);
                    listado.Add(artista);
                }
            }
            return listado;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            ArtistaGuardar.Nombre = txtNombre.Text;
            ArtistaGuardar.Integrantes = txtInfoArtistas.Text;
            ArtistaGuardar.Genero = cbGenero.Text;
            ArtistaGuardar.Redes_sociales = new Uri(txtweb.Text, UriKind.Absolute);
            ArtistaGuardar.Descripcion = txtDescripción.Text;
            ArtistaGuardar.Contacto = txtContacto.Text;
            ArtistaGuardar.Estado = cbEstado.Text;

            ventana = new Ventana_guardar(ArtistaGuardar);
            ventana.Show();
        }

        private void miSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void miAcercaDe_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aplicación realizada por ...", "Acerca de");
        }
    }

}
