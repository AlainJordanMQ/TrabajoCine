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

namespace TrabajoDeVentas
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
        private void btnVentasBoletos_Click(object sender, RoutedEventArgs e)
        {
            VentaDeBoleto2 v = new VentaDeBoleto2();
            v.Show();
        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipalVentas v = new MenuPrincipalVentas();
            this.Close();
        }
    }

}
