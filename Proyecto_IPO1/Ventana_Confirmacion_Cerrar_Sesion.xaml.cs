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
    /// Lógica de interacción para Ventana_Confirmacion_Cerrar_Sesion.xaml
    /// </summary>
    public partial class Ventana_Confirmacion_Cerrar_Sesion : Window
    {
        public Ventana_Confirmacion_Cerrar_Sesion()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            // Cerrar todas las ventanas activas excepto MainWindow
            foreach (Window window in Application.Current.Windows)
            {
                if (window != this && !(window is MainWindow))
                {
                    window.Close();
                }
            }

            // Mostrar la ventana MainWindow
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            // Cerrar la ventana de confirmación
            this.Close();
        }
    }
}
