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

namespace Proyecto_IPO1
{
    /// <summary>
    /// Lógica de interacción para Ventana_guardar.xaml
    /// </summary>
    public partial class Ventana_guardar : Window
    {
        public Ventana_guardar(Artista artista)
        {
            InitializeComponent();
            String DatosArtistas = "Datos de los artistas a guardar: \n";
            DatosArtistas += "Nombre: " + artista.Nombre + "Contacto: " + artista.Contacto +
                "Genero: " + artista.Genero + "Estado: " + artista.Estado;

            txtContenido.Text = DatosArtistas;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
