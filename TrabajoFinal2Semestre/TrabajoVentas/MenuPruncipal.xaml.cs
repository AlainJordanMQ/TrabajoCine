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
    /// Lógica de interacción para MenuPruncipal.xaml
    /// </summary>
    public partial class MenuPruncipal : Window
    {
        public MenuPruncipal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IngresarDuldes v = new IngresarDuldes();
            v.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IngresarPeliculas v = new IngresarPeliculas();
            v.Show();
        }

        private void btnVentasBoletos_Click(object sender, RoutedEventArgs e)
        {
            VentaBoletos v = new VentaBoletos();
            v.Show();
        }

        private void btnSalas_Click(object sender, RoutedEventArgs e)
        {
            VentanaSalas v = new VentanaSalas();
            v.Show();
        }

        private void btnVideos_Click(object sender, RoutedEventArgs e)
        {
            Video v = new Video();
            v.Show();
        }

        private void btnGraficas_Click(object sender, RoutedEventArgs e)
        {
            Graficar v = new Graficar();
            v.Show();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MenuPruncipal v = new MenuPruncipal();
            this.Close();
        }
    }
}
