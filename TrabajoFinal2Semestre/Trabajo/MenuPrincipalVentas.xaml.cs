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
    /// Lógica de interacción para MenuPrincipalVentas.xaml
    /// </summary>
    public partial class MenuPrincipalVentas : Window
    {
        public MenuPrincipalVentas()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Dirige a la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVentasBoletos_Click(object sender, RoutedEventArgs e)
        {
            VentaBoletos v = new VentaBoletos();
            v.Show();
        }
        /// <summary>
        /// Dirige a la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVideos_Click(object sender, RoutedEventArgs e)
        {
            Video v = new Video();
            v.Show();
        }
        /// <summary>
        /// Dirige a la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MenuPruncipal v = new MenuPruncipal();
            this.Close();
        }

    }
}
