using GeneradoraDeDatos;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
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
using Trabajo.BIZ;
using Trabajo.COMMON.Interfaces;
using Trabajo.DAL;

namespace Trabajo
{
    /// <summary>
    /// Lógica de interacción para Graficar.xaml
    /// </summary>
    public partial class Graficar : Window
    {
        IManejadorEstadiscos manejadorEstadiscos;
        IManejadorPeliculas manejadorPelicula;
        Generadora generador;
        Random r = new Random();
        public Graficar()
        {
            InitializeComponent();
            btnCalcular.Click += BtnCalcular_Click;
            generador = new Generadora();
            manejadorEstadiscos = new ManejadorEstadisticos(new RepositorioEstadisticos());
            manejadorPelicula = new ManejadorPeliculas(new RepositorioPeliculas());
            ActualizarComboEstadisticos();
        }
        /// <summary>
        /// Permite actualizar los combos
        /// </summary>
        private void ActualizarComboEstadisticos()
        {
            cmbPelicula.ItemsSource = null;
            cmbPelicula.ItemsSource = manejadorPelicula.Listar;
        }
        /// <summary>
        /// Calcula y grafica los elmentos de la grafica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (cmbPelicula.Text != "")
            {
                EncontrarFinal();
                float inferior = 1;
                float superior = 2;
                float incremento = 1;
                int[] bolef = { 0, bol };
                generador.GenerarDatos(inferior, superior, incremento, bolef);
                Tabla.ItemsSource = null;
                Tabla.ItemsSource = generador.Puntos;
                PlotModel model = new PlotModel();
                LinearAxis ejeX = new LinearAxis();
                ejeX.Minimum = 0;//double.Parse(txbLimInferor.Text);
                ejeX.Maximum = bol+1;//double.Parse(txbLimSuperior.Text);
                ejeX.Position = AxisPosition.Bottom;
                ejeX.Title = "";

                LinearAxis ejeY = new LinearAxis();
                ejeY.Minimum = 0;//generador.Puntos.Min(p => p.Y);
                ejeY.Maximum = bol+1;//generador.Puntos.Max(p => p.Y);
                ejeY.Position = AxisPosition.Left;
                ejeY.Title = "Cantidad de boletos vendidos";


                model.Axes.Add(ejeX);
                model.Axes.Add(ejeY);
                model.Title = "Datos generados";
                LineSeries linea = new LineSeries();
                foreach (var item in generador.Puntos)
                {
                    linea.Points.Add(new DataPoint(item.X, item.Y));
                }
                linea.Title = "Valores generados";
                linea.Color = OxyColor.FromRgb(byte.Parse(r.Next(0, 255).ToString()), byte.Parse(r.Next(0, 255).ToString()), byte.Parse(r.Next(0, 255).ToString()));
                model.Series.Add(linea);
                Grafica.Model = model;
                botonBloquear(true);
            }
            else
            {
                MessageBox.Show("Error no se selecciono ninguna pelicula", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        /// <summary>
        /// Bloque el boton
        /// </summary>
        /// <param name="value"> recibe un verdadero o un falso </param>

        private void botonBloquear(bool value)
        {
            btnCalcular.IsEnabled = !value;
        }

        string[] Boletos = new string[50];
        int bol = 0;
        int[] bole = new int[50];
        int contador = 0;
        /// <summary>
        /// Encuentra el valor final de los boletos
        /// </summary>
        private void EncontrarFinal()
        {
            string d = cmbPelicula.Text;
            manejadorEstadiscos.Pelicula(d);
            for (int i = 0; i < manejadorEstadiscos.Pelicula(d).Count; i++)
            {
                Boletos[i] = Convert.ToString(manejadorEstadiscos.Pelicula(d)[i]);
                bole[contador] = int.Parse(Boletos[i]);
                bol = bol + int.Parse(Boletos[i]);
                contador = contador + 1;
            }
        }
        /// <summary>
        /// Permite salir de la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Graficar v = new Graficar();
            this.Close();
        }
    }
}
