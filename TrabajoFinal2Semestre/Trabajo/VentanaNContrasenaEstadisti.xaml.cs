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
    /// Lógica de interacción para VentanaNContrasenaEstadisti.xaml
    /// </summary>
    public partial class VentanaNContrasenaEstadisti : Window
    {
        public VentanaNContrasenaEstadisti()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Permite guardar la contrasena
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuardarContrasena_Click(object sender, RoutedEventArgs e)
        {
            GenerarEstadis archivo = new GenerarEstadis();
            string usuario;
            string contrasena;
            string contrasena2;
            usuario = txbNuevoUsuario.Text;
            contrasena = txbNuevaContrasena.Text;
            contrasena2 = txbNuevaContrasena2.Text;
            try
            {


                if (contrasena == contrasena2)
                {
                    if (archivo.Genrar(usuario, contrasena))
                    {
                        MessageBox.Show("Usuario y Contraseña modificado", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        MessageBox.Show("Usuario y Contraseña no se pudo modificar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no son iguales", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
        /// <summary>
        /// Permite slair
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            LeerContrasenaEstadistica v = new LeerContrasenaEstadistica();
            //v.Show();
            this.Close();

        }
    }
}
