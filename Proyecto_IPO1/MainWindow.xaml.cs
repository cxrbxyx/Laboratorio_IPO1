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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.Json;
using System.Xml;
using System.Diagnostics.Contracts;




namespace Proyecto_IPO1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 



    public partial class MainWindow : Window
    {

        private String pass;
        private List<Usuario> usuarios;
        public MainWindow()
        {
            InitializeComponent();
            usuarios = new List<Usuario>();
            usuarios = CargaUsuarios();
        }


        //Evento que se ejecuta cuando se presiona la tecla enter en el campo de usuario
        private void TxtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                passContrasena.IsEnabled = true;
                passContrasena.Focus();
            }
        }

        // Evento que se ejecuta cuando se presiona el boton de iniciar sesion
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            {
                string nombreUsuario = txtUsuario.Text;
                string contrasena = passContrasena.Password;

                bool credencialesValidas = usuarios.Exists(u => u.NombreUsuario == nombreUsuario && u.Contrasena == contrasena);

                if (credencialesValidas)
                {
                    MessageBox.Show("Inicio de sesión exitoso", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                    formulario_Festivales formulario_festival = new formulario_Festivales();
                    formulario_festival.Show();
                   

                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        //Evento que se ejecuta cuando el campo de contraseña obtiene el foco
        private void passContrasena_GotFocus(object sender, RoutedEventArgs e)
        {
            btnLogin.IsEnabled = true;
            btnLogin.Visibility = Visibility.Visible;
        }



        //TODO: Implementar la carga de usuarios desde un archivo XML
        private List<Usuario> CargaUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            XmlDocument database = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("database/user_database.xml", UriKind.Relative));
            database.Load(fichero.Stream);

            foreach (XmlNode node in database.DocumentElement.ChildNodes)
            {

                var nuevoUsuario = new Usuario("", "")
                {
                    NombreUsuario = node.Attributes["NombreUsuario"].Value,
                    Contrasena = node.Attributes["Contrasena"].Value
                };

                usuarios.Add(nuevoUsuario);

            }
            return usuarios;
        }



    }
}
