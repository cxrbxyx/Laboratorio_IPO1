using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
        private List<Festival> Lista_festivales;
        public formulario_Festivales()
        {
            InitializeComponent();
            try
            {

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
                var festival = new Festival("", null, null, null, null, null, "", null, null)
                {
                    Nombre = node.Attributes["Nombre"].Value,
                    Redes_sociales = new Uri(node.Attributes["Redes_sociales"].Value, UriKind.Absolute),
                    Fechas = node.Attributes["Fechas"].Value.Split(',').ToList(),
                    Artistas = node.Attributes["Artistas"].Value.Split(',').Select(a => new Artista(a, null, null, null, null, null, null, null, null)).ToList(),
                    Precios = node.Attributes["Precios"].Value.Split(',').ToList(),
                    Caratula = new Uri(node.Attributes["Caratula"].Value, UriKind.Relative),
                    Estado = node.Attributes["Estado"].Value,
                    Descripcion = node.Attributes["Descripcion"].Value,
                    Cartelera = new Uri(node.Attributes["Cartelera"].Value, UriKind.Relative),

                };
                string nombreFestival = festival.Nombre.Replace(" ", "_");
                festival.Contacto = nombreFestival.ToLower() + "@festigest.com";
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

        private void miSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void miEliminarItemLB_Click(object sender, RoutedEventArgs e)
        {
            var festivalSeleccionado = lstListaFestivales.SelectedItem as Festival;
            if (festivalSeleccionado != null)
            {
                Lista_festivales.Remove(festivalSeleccionado);
                lstListaFestivales.ItemsSource = null;
                lstListaFestivales.ItemsSource = Lista_festivales;
            }
        }

        private void miAniadirItemLB_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Text = "";
            txtContacto.Text = "";
            txtweb.Text = "";

            // Limpia la colección de artistas en lugar de llamar a lbArtistas.Items.Clear()
            if (lbArtistas.ItemsSource is List<Artista> artistas)
            {
                artistas.Clear();
            }

            txtDescripcion.Text = "";
            if(lbPrecios.ItemsSource is List<string> precios)
            {
                precios.Clear();
            }

            var festival = new Festival("", null, null, null, null, null, "", null, null);
            Lista_festivales.Add(festival);
            lstListaFestivales.ItemsSource = null;
            lstListaFestivales.ItemsSource = Lista_festivales;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (lstListaFestivales.SelectedItem is Festival festivalSeleccionado)
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    MessageBox.Show("El campo Nombre no puede estar vacío.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                festivalSeleccionado.Nombre = txtNombre.Text;
                festivalSeleccionado.Contacto = txtNombre.Text.ToLower().Replace(" ","_")+"@festigest.com";
                festivalSeleccionado.Redes_sociales = string.IsNullOrWhiteSpace(txtweb.Text) ? null : new Uri(txtweb.Text, UriKind.Absolute);
                festivalSeleccionado.Descripcion = txtDescripcion.Text;
                festivalSeleccionado.Estado = "";

                // Actualiza la lista de festivales para reflejar los cambios en la UI
                lstListaFestivales.ItemsSource = null;
                lstListaFestivales.ItemsSource = Lista_festivales;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un festival de la lista para guardar los cambios.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void calFechas_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstListaFestivales.SelectedItem is Festival festivalSeleccionado)
            {
                festivalSeleccionado.Fechas = calFechas.SelectedDates.Select(d => d.ToString("dd/MM/yyyy")).ToList();
            }
        }

        private void lstListaFestivales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstListaFestivales.SelectedItem is Festival festivalSeleccionado)
            {
                calFechas.SelectedDates.Clear();
                if(festivalSeleccionado.Fechas != null) { 
                    foreach (var fecha in festivalSeleccionado.Fechas)
                    {
                        if (DateTime.TryParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                        {
                            calFechas.SelectedDates.Add(date);
                        }
                    }
                }
            }
        }

        private void btnUsuario_Click(object sender, RoutedEventArgs e)
        {
            var ventanaUsuario = new Ventana_Usuario();
            ventanaUsuario.Show();
        }

        private void miAcercaDe_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("APP: FestiFest V: 1.0.0\n Fecha de realización: 17/01/2025\n Aplicación realizada por Javier Garzás y Pablo Carbayo", "Acerca de");
        }

        private void btnCargarImagen_Click(object sender, RoutedEventArgs e)
        {
            var abrirDialog = new OpenFileDialog();
            abrirDialog.Filter = "Images|*.jpg;*.gif;*.bmp;*.png";
            if (abrirDialog.ShowDialog() == true)
            {
                try
                {
                    var bitmap = new BitmapImage(new Uri(abrirDialog.FileName, UriKind.Absolute));
                    imgCaratula.Source = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen " + ex.Message);
                }
            }
        }
    }
}
