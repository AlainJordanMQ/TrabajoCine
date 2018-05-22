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


namespace Trabajo
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// Permite leer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Leer contrasena = new Leer();
            string contrasenaIngresada;
            string usuarioIngresada;
            contrasenaIngresada = txbContrasena.Password;
            usuarioIngresada = txbUsuario.Text;

            if (contrasenaIngresada == contrasena.contrasena() && usuarioIngresada == contrasena.usuario())
            {
                MenuPruncipal v = new MenuPruncipal();
                v.Show();
                limpiarCampos();
            }
            else
            {
                MessageBox.Show("Erro usuario o contraseña incorrecta", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                limpiarCampos();
            }


        }
        /// <summary>
        /// Permite limpiar
        /// </summary>
        private void limpiarCampos()
        {
            txbContrasena.Clear();
            txbUsuario.Clear();
        }
        /// <summary>
        /// Permite modificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            Leer contrasena = new Leer();
            string contrasenaIngresada;
            string usuarioIngresada;
            contrasenaIngresada = txbContrasena.Password;
            usuarioIngresada = txbUsuario.Text;

            if (contrasenaIngresada == contrasena.contrasena() && usuarioIngresada == contrasena.usuario())
            {
                VentanaNContrasena v = new VentanaNContrasena();
                v.Show();
                limpiarCampos();
            }
            else
            {
                MessageBox.Show("Erro usuario o contraseña incorrecta", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                limpiarCampos();
            }
        }
        /// <summary>
        /// Pemrite salir de las ventanas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MainWindow v = new MainWindow();
            this.Close();
        }
    }
}
