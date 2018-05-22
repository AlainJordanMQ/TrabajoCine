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
using Trabajo.COMMON.Entidades;
using Trabajo.COMMON.Interfaces;
using Trabajo.DAL;

namespace Trabajo
{
    /// <summary>
    /// Lógica de interacción para TablaDeDato.xaml
    /// </summary>
    public partial class TablaDeDato : Window
    {
        IManejadorEstadiscos manejadorEstadiscos;
        IManejadorPeliculas manejadorPeliculas;
        IManejadorCostoFinal manejadorCostoFinal;
        public TablaDeDato()
        {
            InitializeComponent();
            manejadorPeliculas = new  ManejadorPeliculas(new RepositorioPeliculas());
            manejadorEstadiscos = new ManejadorEstadisticos(new RepositorioEstadisticos());
            manejadorCostoFinal = new ManejadorCosto(new RepositorioCosto());
            ActualizarComboPeliculas();
        }
        /// <summary>
        /// Actualiza los combos
        /// </summary>
        private void ActualizarComboPeliculas()
        {
            cmbPelicula.ItemsSource = null;
            cmbPelicula.ItemsSource = manejadorPeliculas.Listar;
        }
        /// <summary>
        /// Toma el valor de la pelicula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            if(cmbPelicula.Text == "")
            {
                MessageBox.Show("Error no se selecciono ninguna pelicula", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                ActualizarTablaPeliculas();
                EncontrarFinal();
                EncontrarFinalDinero();
                bol = 0;
                bolD = 0;
            }
            ActualizarTablaPeliculas();
            EncontrarFinal();
            EncontrarFinalDinero();
            bol = 0;
            bolD = 0;
        }
        /// <summary>
        /// Actualiza la tabla
        /// </summary>
        private void ActualizarTablaPeliculas()
        {
            string d = cmbPelicula.Text;
            //manejadorDeportesPunta.Deporte(d);
            manejadorPeliculas.Pelicula(d);
            //cmbEquipo.ItemsSource = null;
            dtgTabla.ItemsSource = manejadorPeliculas.Pelicula(d);
        }

        string[] Boletos = new string[50];
        int bol = 0;
        int[] bole = new int[50];
        int contador = 0;
        /// <summary>
        /// Encuentra el valor final de cantidad de boletos
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
            txbTotal.Text = bol.ToString();
        }
        string[] Dinero = new string[50];
        int bolD = 0;
        int[] dine = new int[50];
        int contadorD = 0;
        /// <summary>
        /// Encuentra el valor final de dinero
        /// </summary>
        private void EncontrarFinalDinero()
        {
            
            
            string t = cmbPelicula.Text;
            manejadorCostoFinal.Pelicula(t);
            for (int i = 0; i < manejadorCostoFinal.Pelicula(t).Count; i++)
            {
                Dinero[i] = Convert.ToString(manejadorCostoFinal.Pelicula(t)[i]);
                dine[contador] = int.Parse(Dinero[i]);
                bolD = bolD + int.Parse(Dinero[i]);
                contadorD = contadorD + 1;
            }
            txbTotalDinero.Text = bolD.ToString();

        }

        private void btnExportar_Click(object sender, RoutedEventArgs e)
        {
            dtgTabla.SelectAllCells();
            dtgTabla.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dtgTabla);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            dtgTabla.UnselectAllCells();
            System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"C:\Trabajo6F/Trabajo.xls");
            file1.WriteLine(result.Replace(',', ' '));
            file1.Close();
            MessageBox.Show("Se exporto", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
