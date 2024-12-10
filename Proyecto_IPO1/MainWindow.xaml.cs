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
            //CargarUsuariosDesdeCSV(usuarios);
            Usuario user = new Usuario();
            user.NombreUsuario = "admin";
            user.Contrasena = "admin";
            usuarios.Add(user);
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
                    formulario_Artista formulario_Artista = new formulario_Artista();
                    formulario_Artista.Show();
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



        //TODO: Implementar la carga de usuarios desde un archivo CSV
        /* public void CargarUsuariosDesdeCSV(List<Usuario> usuarios)
         {
             usuarios.Clear();
             string rutaArchivo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database", "user_database.csv");
             Console.WriteLine(rutaArchivo);
             try
             {
                 // Leer todas las líneas del archivo CSV
                 var lineas = File.ReadAllLines(rutaArchivo);

                 // Omitir la primera línea si contiene encabezados
                 for (int i = 1; i < lineas.Length; i++)
                 {
                     var linea = lineas[i];

                     // Separar los valores por coma (asumiendo que el delimitador es una coma)
                     var partes = linea.Split(',');

                     if (partes.Length >= 2)
                     {
                         Usuario usuario = new Usuario
                         {
                             NombreUsuario = partes[0].Trim(),
                             Contrasena = partes[1].Trim()
                         };

                         usuarios.Add(usuario);
                     }
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine($"Error al cargar usuarios: {ex.Message}");
             }
         }
        */
    }



}
