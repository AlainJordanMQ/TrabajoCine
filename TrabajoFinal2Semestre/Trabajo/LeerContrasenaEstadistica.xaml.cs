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
using Trabajo.Contrasenas;

namespace Trabajo
{
    /// <summary>
    /// Lógica de interacción para LeerContrasenaEstadistica.xaml
    /// </summary>
    public partial class LeerContrasenaEstadistica : Window
    {
        public LeerContrasenaEstadistica()
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
            LeerEstadis contrasena = new LeerEstadis();
            string contrasenaIngresada;
            string usuarioIngresada;
            contrasenaIngresada = txbContrasena.Password;
            usuarioIngresada = txbUsuario.Text;

            if (contrasenaIngresada == contrasena.contrasena() && usuarioIngresada == contrasena.usuario())
            {
                MenuPrincipalEstadisticos v = new MenuPrincipalEstadisticos();
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
        /// Limpia los campos
        /// </summary>
        private void limpiarCampos()
        {
            txbContrasena.Clear();
            txbUsuario.Clear();
        }

        /// <summary>
        /// Permite modificar usuario y contrasena
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            LeerEstadis contrasena = new LeerEstadis();
            string contrasenaIngresada;
            string usuarioIngresada;
            contrasenaIngresada = txbContrasena.Password;
            usuarioIngresada = txbUsuario.Text;

            if (contrasenaIngresada == contrasena.contrasena() && usuarioIngresada == contrasena.usuario())
            {
                VentanaNContrasenaEstadisti v = new VentanaNContrasenaEstadisti();
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
        /// Permite salir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            LeerContrasenaEstadistica v = new LeerContrasenaEstadistica();
            this.Close();
        }
    }
}
