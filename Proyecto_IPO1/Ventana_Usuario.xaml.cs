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
    /// Lógica de interacción para Ventana_Usuario.xaml
    /// </summary>
    public partial class Ventana_Usuario : Window
    {
        public Ventana_Usuario()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ventana_CerrarSesion = new Ventana_Confirmacion_Cerrar_Sesion();
            ventana_CerrarSesion.Show();
        }
    }
}
