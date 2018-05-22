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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Trabajo
{
    /// <summary>
    /// Lógica de interacción para Cargando.xaml
    /// </summary>
    public partial class Cargando : Window
    {
        public Cargando()
        {
            InitializeComponent();
            CargandoProgreso();
            pb1.ValueChanged += pb1_EvaluarProgreso;
        }
        /// <summary>
        /// Permite abrir la siguiente ventana cuando la barra cargue en 100
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb1_EvaluarProgreso(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(pb1.Value == 100)
            {
                SeleccionarElTrabajo v = new SeleccionarElTrabajo();
                v.Show();
                this.Close();
            }
        }
        /// <summary>
        /// Permite crear la barra de cargado
        /// </summary>
        private void CargandoProgreso()
        {
            Duration dur = new Duration(TimeSpan.FromSeconds(30));
            DoubleAnimation animacion = new DoubleAnimation(200.0, dur);
            pb1.BeginAnimation(System.Windows.Controls.Primitives.RangeBase.ValueProperty, animacion);
        }
    }
}
