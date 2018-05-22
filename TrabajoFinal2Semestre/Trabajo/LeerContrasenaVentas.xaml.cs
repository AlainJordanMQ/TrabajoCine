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
    /// Lógica de interacción para LeerContrasenaVentas.xaml
    /// </summary>
    public partial class LeerContrasenaVentas : Window
    {
        public LeerContrasenaVentas()
        {
            InitializeComponent();
        }
        /// <summary>
        /// permite Leer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LeerVentas contrasena = new LeerVentas();
            string contrasenaIngresada;
            string usuarioIngresada;
            contrasenaIngresada = txbContrasena.Password;
            usuarioIngresada = txbUsuario.Text;

            if (contrasenaIngresada == contrasena.contrasena() && usuarioIngresada == contrasena.usuario())
            {
                MenuPrincipalVentas v = new MenuPrincipalVentas();
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
        /// Limpia los cambios
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
            LeerVentas contrasena = new LeerVentas();
            string contrasenaIngresada;
            string usuarioIngresada;
            contrasenaIngresada = txbContrasena.Password;
            usuarioIngresada = txbUsuario.Text;

            if (contrasenaIngresada == contrasena.contrasena() && usuarioIngresada == contrasena.usuario())
            {
                VentanaNContrasenaVentas v = new VentanaNContrasenaVentas();
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
            LeerContrasenaVentas v = new LeerContrasenaVentas();
            this.Close();
        }
    }
}
