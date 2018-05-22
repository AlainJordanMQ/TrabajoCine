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
    /// Lógica de interacción para MenuPrincipalEstadisticos.xaml
    /// </summary>
    public partial class MenuPrincipalEstadisticos : Window
    {
        public MenuPrincipalEstadisticos()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Dirige a la venta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGraficas_Click(object sender, RoutedEventArgs e)
        {
            Graficar v = new Graficar();
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
        /// <summary>
        /// Dirige a la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTablas_Click(object sender, RoutedEventArgs e)
        {
            TablaDeDato v = new TablaDeDato();
            v.Show();
        }
    }
}
