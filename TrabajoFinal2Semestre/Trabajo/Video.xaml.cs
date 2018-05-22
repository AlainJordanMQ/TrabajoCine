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
    /// Lógica de interacción para Video.xaml
    /// </summary>
    public partial class Video : Window
    {
        public Video()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Muestra la siguiente ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrailer1_Click(object sender, RoutedEventArgs e)
        {
            ReporducirVideo v = new ReporducirVideo();
            v.Show();
        }
        /// <summary>
        /// Muestra la siguiente ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrailer2_Click(object sender, RoutedEventArgs e)
        {
            ReproducirVideo2 v = new ReproducirVideo2();
            v.Show();
        }
        /// <summary>
        /// Muestra la siguiente ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrailer3_Click(object sender, RoutedEventArgs e)
        {
            ReproducirVideo3 v = new ReproducirVideo3();
            v.Show();
        }
        /// <summary>
        /// Muestra la siguiente ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrailer4_Click(object sender, RoutedEventArgs e)
        {
            ReproducirVideo4 v = new ReproducirVideo4();
            v.Show();
        }
    }
}
