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
    /// Lógica de interacción para formulario_Festivales.xaml
    /// </summary>
    public partial class formulario_Festivales : Window
    {
        public formulario_Festivales()
        {
            InitializeComponent();
            try
            {
                List<Festival> Lista_festivales = new List<Festival>();
                Lista_festivales = CargarContenidoXMLFestivales();
                lstListaFestivales.ItemsSource = Lista_festivales;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los festivales: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private List<Festival> CargarContenidoXMLFestivales()
        {
            List<Festival> listado = new List<Festival>();
            XmlDocument database = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("database/festivales.xml", UriKind.Relative));
            database.Load(fichero.Stream);

            foreach (XmlNode node in database.DocumentElement.ChildNodes)
            {
                var festival = new Festival("",null,null,null,null,null,"",null,null)
                {
                    Nombre = node.Attributes["Nombre"].Value,
                    Redes_sociales = new Uri(node.Attributes["Redes_sociales"].Value, UriKind.Absolute),
                    Fechas = node.Attributes["Fechas"].Value.Split(';').ToList(),
                    Artistas = node.Attributes["Artistas"].Value.Split(',').Select(a=> new Artista(a,null,null,null,null,null,null,null,null)).ToList(),
                    Precios = node.Attributes["Precios"].Value.Split(',').ToList(),
                    Caratula = new Uri(node.Attributes["Caratula"].Value, UriKind.Relative),
                    Estado = node.Attributes["Estado"].Value,
                    Descripcion = node.Attributes["Descripcion"].Value,
                    Cartelera = new Uri(node.Attributes["Cartelera"].Value, UriKind.Relative),
                };
                listado.Add(festival);

            }
            return listado;
        }

        private void txtDescripción_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lbArtistas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstListaFestivales.SelectedItem is Festival artistaSeleccionado)
            {
                // Lógica para abrir la página del artista en el formulario de artistas
                AbrirFormularioArtista(artistaSeleccionado);
            }
        }

        private void AbrirFormularioArtista(Festival festival)
        {
            // Aquí puedes implementar la lógica para abrir el formulario de artistas
            // y pasarle el objeto artistaSeleccionado. Por ejemplo:
            var formularioArtistas = new formulario_Artista(festival);
            formularioArtistas.Show();
        }

    }
}
