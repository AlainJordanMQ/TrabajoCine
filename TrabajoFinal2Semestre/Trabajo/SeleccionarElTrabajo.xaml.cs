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

namespace Trabajo
{
    /// <summary>
    /// Lógica de interacción para SeleccionarElTrabajo.xaml
    /// </summary>
    public partial class SeleccionarElTrabajo : Window
    {
        public SeleccionarElTrabajo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Envia a la siguiente ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGeneradorDeDatos_Click(object sender, RoutedEventArgs e)
        {
            MainWindow v = new MainWindow();
            v.Show();
        }
        /// <summary>
        /// Envia a la siguiente ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEstadisticos_Click(object sender, RoutedEventArgs e)
        {
            LeerContrasenaEstadistica v = new LeerContrasenaEstadistica();
            v.Show();
        }
        /// <summary>
        /// Envia a la siguiente ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVentas_Click(object sender, RoutedEventArgs e)
        {
            LeerContrasenaVentas v = new LeerContrasenaVentas();
            v.Show();
        }
        /// <summary>
        /// Envia a la siguiente ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {

            App.Current.Shutdown();
        }
    }
}
