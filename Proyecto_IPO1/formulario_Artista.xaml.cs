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
    /// Lógica de interacción para formulario_Artista.xaml
    /// </summary>
    public partial class formulario_Artista : Window
    {
        private Artista artista_actual = new Artista("Extremoduro",
        "1989", "Robe Iniesta", "Rock transgresivo", null, "Aquí va el argumento");
        public formulario_Artista()
        {
            InitializeComponent();
            DataContext = artista_actual;
        }
    }
}
