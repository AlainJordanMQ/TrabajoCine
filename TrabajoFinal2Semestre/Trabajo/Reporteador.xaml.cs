using Microsoft.Reporting.WinForms;
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
    /// Lógica de interacción para Reporteador.xaml
    /// </summary>
    public partial class Reporteador : Window
    {
        string reporte;
        List<ReportDataSource> origenes;
       // List<ReportParameter> parametros;
        bool cargado;
        /// <summary>
        /// Permite generar el reporte
        /// </summary>
        /// <param name="nombreReporte"></param>
        /// <param name="datos"></param>
        public Reporteador(string nombreReporte, List<ReportDataSource> datos /*, List<ReportParameter> parametros*/)
        {
            InitializeComponent();
            reporte = nombreReporte;
            origenes = datos;
            //this.parametros = parametros;
            Contenedor.Load += Contenedor_Load;
        }

        /// <summary>
        /// Genera uncontenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Contenedor_Load(object sender, EventArgs e)
        {
            if (!cargado)
            {
                Contenedor.LocalReport.ReportEmbeddedResource = reporte;
                foreach (var item in origenes)
                {
                    Contenedor.LocalReport.DataSources.Add(item);
                }
                /*if(parametros !=null)
                {
                    Contenedor.LocalReport.SetParameters(parametros);
                }*/
                Contenedor.RefreshReport();
                cargado = true;
            }   
        }
    }
}
