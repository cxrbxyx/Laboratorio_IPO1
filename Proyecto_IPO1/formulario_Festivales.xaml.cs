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
                var festival = new Festival("", null, null, null, null, null, "", null, null, null)
                {
                    Nombre = node.Attributes["Nombre"].Value,
                    Redes_sociales = node.Attributes["Redes_sociales"].Value,
                    Fechas = node.Attributes["Fechas"].Value.Split(',').ToList(),
                    Artistas = node.Attributes["Artistas"].Value.Split(',').Select(a => new Artista(a, null, null, null, null, null, null, null, null)).ToList(),
                    Precios = node.Attributes["Precios"].Value.Split(',').ToList(),
                    Caratula = new Uri(node.Attributes["Caratula"].Value, UriKind.Relative),
                    Estado = node.Attributes["Estado"].Value,
                    Descripcion = node.Attributes["Descripcion"].Value,
                    Cartelera = new Uri(node.Attributes["Cartelera"].Value, UriKind.Relative),
                    Genero = null

                };
                string nombreFestival = festival.Nombre.Replace(" ", "_");
                festival.Contacto = nombreFestival.ToLower() + "@festigest.com";
                listado.Add(festival);

            }
            return listado;
        }
        

        private void lbArtistas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lstListaFestivales.SelectedItem is Festival festivalSeleccionado )
            {
                if (festivalSeleccionado.Artistas is null)
                {
                    MessageBox.Show("No hay artistas para este festival.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    AbrirFormularioArtista(festivalSeleccionado);
                }
            }
        }

        private void AbrirFormularioArtista(Festival festival)
        {
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
            MessageBox.Show("Festival eliminado correctamente.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
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

            var festival = new Festival("", null, null, null, null, null, "", null, null,null);
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
                festivalSeleccionado.Redes_sociales = txtweb.Text;
                festivalSeleccionado.Descripcion = txtDescripcion.Text;
                festivalSeleccionado.Estado = cbEstado.Text;
                festivalSeleccionado.Fechas = calFechas.SelectedDates.Select(d => d.ToString("dd/MM/yyyy")).ToList();
                festivalSeleccionado.Caratula = new Uri(imgCaratula.Source.ToString());
                festivalSeleccionado.Genero = cbGenero.Text;
                // Actualiza la lista de festivales para reflejar los cambios en la UI
                lstListaFestivales.ItemsSource = null;
                lstListaFestivales.ItemsSource = Lista_festivales;

                MessageBox.Show("Cambios guardados correctamente.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
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

        // ...

        private void lstListaFestivales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstListaFestivales.SelectedItem is Festival festivalSeleccionado)
            {
                calFechas.SelectedDates.Clear();
                if (festivalSeleccionado.Fechas != null)
                {
                    foreach (var fecha in festivalSeleccionado.Fechas)
                    {
                        if (DateTime.TryParseExact(fecha, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                        {
                            calFechas.SelectedDates.Add(date);
                        }
                    }
                }
                txtNombre.Text = festivalSeleccionado.Nombre;
                if(festivalSeleccionado.Caratula != null)
                {
                    imgCaratula.Source = new BitmapImage(festivalSeleccionado.Caratula);
                }
                cbEstado.Text = festivalSeleccionado.Estado;
                cbGenero.Text = festivalSeleccionado.Genero;
            }
        }

        private void btnUsuario_Click(object sender, RoutedEventArgs e)
        {
            var ventanaUsuario = new Ventana_Usuario();
            ventanaUsuario.Show();
        }

        private void miAcercaDe_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("APP: GestiFest V: 1.0.0\n Fecha de realización: 17/01/2025\n Aplicación realizada por Javier Garzás y Pablo Carbayo", "Acerca de");
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

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("1. Para selecionar un festival haga click izquierdo sobre el en el panel de la izquierda.\n" +
                "2. Si desea eliminar o añadir uno nuevo haga click derecho en el panel izquierdo.\n2a. Añandir item añade un festival nuevo vacío. Una vez creado se debe " +
                "modificar los apartados correspondientes." +
                "3. Para modificar un festival es obligatorio introducir un nombre el resto de datos son opcionales, una vez introducidos debe darle al boton guardar\n" +
                "3.a Los artistas, precios y fechas no se pueden ni añadir ni modificar debido a la implementación del programa.\n" +
                "4. El contacto de un festival se autocompletará de la siguiente manera: <nombre>@festigest.com\n" +
                "5. Para cerrar sesión haga click en su foto de perfil situada en la esquina superior derecha.");
        }
    }
}
