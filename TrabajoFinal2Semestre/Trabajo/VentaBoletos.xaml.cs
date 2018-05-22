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
using Trabajo.BIZ;
using Trabajo.COMMON.Entidades;
using Trabajo.COMMON.Interfaces;
using Trabajo.COMMON.Modelos;
using Trabajo.DAL;

namespace Trabajo
{
    /// <summary>
    /// Lógica de interacción para VentaBoletos.xaml
    /// </summary>
    public partial class VentaBoletos : Window
    {
        enum accion
        {
            Nuevo,
            Editar
        }
        accion accionNoAsiento;
        accion estadisticos;
        IManejadorPeliculas manejadorPeliculas;
        IManejadorSalas manejadorSalas;
        IManejadorDulces manejadorDulces;
        IManejadorNumeroSala manejadorNumeroSala;
        IManejadorEstadiscos manejadorEstadisticos;
        public VentaBoletos()
        {
            InitializeComponent();
            manejadorPeliculas = new ManejadorPeliculas(new RepositorioPeliculas());
            manejadorSalas = new ManejadorSalas(new RepositorioSalas());
            manejadorDulces = new ManejadorDulces(new RepopsitorioDulces());
            manejadorNumeroSala = new ManejadorNumeroSala(new RepositorioNumeroSala());
            manejadorEstadisticos = new ManejadorEstadisticos(new RepositorioEstadisticos());
            ActualizarCombos();
            ActualizarTablaVentas();
           
            todoBloque(false);
           
        }
        /// <summary>
        /// Bloquea todos los botones
        /// </summary>
        /// <param name="value"></param>
        private void todoBloque(bool value)
        {
            txbCambio.IsEnabled = value;
            txbRecibido.IsEnabled = value;
            txbCalcular.IsEnabled = value;
            txbTotalPagar.IsEnabled = value;
            btnImprimir.IsEnabled = value;
            btnNuevo.IsEnabled = !value;
            btnEliminar.IsEnabled = !value;
            btnSalir.IsEnabled = value;
            btnFinalizar.IsEnabled = value;
            btnAceptar.IsEnabled = value;
            btnCalcularPagar.IsEnabled = value;
            cmbDulce.IsEnabled = value;
            cmbNoAsiento.IsEnabled = value;
            cmbPelicula.IsEnabled = value;
            cmbSala.IsEnabled = value;
        }

        /// <summary>
        /// Actualiza la tabla
        /// </summary>
        private void ActualizarTablaVentas()
        {
            dtgTabla.ItemsSource = null;
            dtgTabla.ItemsSource = manejadorEstadisticos.Listar;//.OrderBy(p => p.FechaDeEstreno);
        }
        /// <summary>
        /// Actualiza los combos
        /// </summary>
        private void ActualizarCombos()
        {
            cmbPelicula.ItemsSource = null;
            cmbPelicula.ItemsSource = manejadorPeliculas.Listar;

            cmbSala.ItemsSource = null;
            cmbSala.ItemsSource = manejadorSalas.Listar;

            cmbDulce.ItemsSource = null;
            cmbDulce.ItemsSource = manejadorDulces.Listar;
        }
        string[] MarcadorFinal = new string[50];
        string mar;
        string[] nume = new string[70];
        /// <summary>
        /// Encuentra el valor de la sala
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            
            string d = cmbSala.Text;
            manejadorNumeroSala.Salas(d);
            //manejadorSalas.BuscarPorId(d);
            cmbNoAsiento.ItemsSource = null;
            cmbNoAsiento.ItemsSource = manejadorNumeroSala.Salas(d);
            //cmbNoAsiento.ItemsSource = manejadorSalas.BuscarPorId(d).ToString();
            //txnNoAsientos.Text = manejadorNumeroSala.Salas(d).ToString();
            /*for (int i = 0; i < manejadorNumeroSala.Salas(d).Count; i++)
            {
                MarcadorFinal[i] = Convert.ToString(manejadorNumeroSala.Salas(d)[i]);
                // mar = mar + int.Parse( MarcadorFinal[i]);
            }
            mar = MarcadorFinal[0];
            //MarFinal.Text = MarcadorFinal[2];
            //cmbNoAsiento.ItemsSource = null;
            for (int i = 1; i <= int.Parse (mar); i++)
            {
                
                nume[i] = i.ToString();

            }
            foreach (var item in nume)
            {
               // cmbNoAsiento.Items.Add(item);
            }*/
        }

        private void btnAceptarNoAsiento_Click(object sender, RoutedEventArgs e)
        {
            
        }

        string NodeAsientos;
        double NoAsientosFinal;
        /// <summary>
        /// Creo los estadisticos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (estadisticos == accion.Nuevo)
            {
                Estadisticos est = new Estadisticos()
                {
                    NombrePelicula = cmbPelicula.Text,
                    CantidadDeBoletos = "1",
                    Costo = txbTotalPagar.Text
                   

                };
                if (manejadorEstadisticos.Agregar(est))
                {
                    MessageBox.Show("Venta agregada correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    botonFi(false);
                }
                else
                {
                    MessageBox.Show("La Venta No se pudo agregar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                Salas sal = cmbSala.SelectedItem as Salas;
                if (sal != null)
                {

                    NodeAsientos = sal.CantidadAsientos;
                    NoAsientosFinal = (double.Parse(NodeAsientos) - 1);
                }
                Salas sala = cmbSala.SelectedItem as Salas;
                //sal.Nombre = txbNombre.Text;
                sala.CantidadAsientos = NoAsientosFinal.ToString();

                if (manejadorSalas.Modificar(sala))
                {
                    //MessageBox.Show("Sala modificada correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    //LimpiarCamposDeSalas();
                    //ActualizarTablaSalas();
                    //PonerBotonesSalasEnEdicion(false);
                }
                else
                {
                    // MessageBox.Show("La Sala No se pudo actualizar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                MessageBox.Show("Venta Exitosa", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        /// <summary>
        /// Habilito el boton imprimir
        /// </summary>
        /// <param name="value"></param>
        private void botonFi(bool value)
        {
            btnImprimir.IsEnabled = !value;
            btnFinalizar.IsEnabled = value;
            btnNuevo.IsEnabled = value;
            btnEliminar.IsEnabled = value;
            btnSalir.IsEnabled = value;
        }

        double cambio;
        /// <summary>
        /// Calculo el cambio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbCalcular_Click(object sender, RoutedEventArgs e)
        { int asientos;
            Salas sal = cmbSala.SelectedItem as Salas;
            asientos = int.Parse( sal.CantidadAsientos);
            if (asientos>0) {
                if (VerificarCampos())
                {
                    if (Esnumero())
                    {
                        cambio = (double.Parse(txbRecibido.Text) - CostoFinal);
                        if (cambio >= 0)
                        {
                            txbCambio.Text = cambio.ToString();
                            MessageBox.Show("Operacion generada correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                            botonImprimir(false);
                        }
                        else
                        {
                            MessageBox.Show("La operacion No se pudo generar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error en el campo Dinero recibido", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error No todos los campos estan completos", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Ya no hay Asientos", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Habilito el boton de finalizar y de salir
        /// </summary>
        /// <param name="value"></param>
        private void botonImprimir(bool value)
        {
            btnFinalizar.IsEnabled = !value;
            btnSalir.IsEnabled = !value;
        }
        /// <summary>
        /// Verifica que los campos esten llenos
        /// </summary>
        /// <returns></returns>
        private bool VerificarCampos()
        {
            if (txbRecibido.Text != "" && cmbDulce.SelectedItem !=null && cmbPelicula.SelectedItem != null && cmbSala.SelectedItem != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Verifica que sea un numero
        /// </summary>
        /// <returns></returns>
        private bool Esnumero()
        {
            int i = 0;
            string s = txbRecibido.Text;
            bool result;
            //throw new NotImplementedException();
            return result = int.TryParse(s, out i); //i now = 108  
        }

        string PrimerCosto;
        string SegundoCosto;
        double CostoFinal;
        /// <summary>
        /// Calcula el totala pagar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalcularPagar_Click(object sender, RoutedEventArgs e)
        {
            int asientos;
            Salas sal = cmbSala.SelectedItem as Salas;
            asientos = int.Parse(sal.CantidadAsientos);
            if (asientos > 0)
            {

                Dulces dul = cmbDulce.SelectedItem as Dulces;
                if (dul != null)
                {

                    PrimerCosto = dul.Costo;
                }

                Peliculas pel = cmbPelicula.SelectedItem as Peliculas;
                if (pel != null)
                {

                    SegundoCosto = pel.Costo;

                }

                CostoFinal = ((double.Parse(PrimerCosto) + double.Parse(SegundoCosto)));
                txbTotalPagar.Text = CostoFinal.ToString();
                habilitar2(false);
                
            }
            else
            {
                MessageBox.Show("Ya no hay Asientos", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Habilita los botones de cambio recibido y calcular
        /// </summary>
        /// <param name="value"></param>
        private void habilitar2(bool value)
        {
            txbCambio.IsEnabled = !value;
            txbRecibido.IsEnabled = !value;
            txbCalcular.IsEnabled = !value;
        }
        /// <summary>
        /// Permite salir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            VentaBoletos v = new VentaBoletos();
            this.Close();
        }
        /// <summary>
        /// Crea el reporte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImprimir_Click(object sender, RoutedEventArgs e)
        {
            try
            {

           
            List<ReportDataSource> datos = new List<ReportDataSource>();
            ReportDataSource ticket = new ReportDataSource();
            List<ModelTicket> tickets = new List<ModelTicket>();
            string d = cmbPelicula.Text;
            int contador = 0;
            foreach (var item in manejadorEstadisticos.Pelicula(d))
            {
                if (contador == 0)
                {
                    tickets.Add(new ModelTicket(item));
                    contador = contador + 1;
                }
            }
            ticket.Value = tickets;
            ticket.Name = "Ticket";
            datos.Add(ticket);

            Reporteador ventana = new Reporteador("Trabajo.Reportes.BoletoVendido.rdlc", datos);
            ventana.ShowDialog();

                todoBloque(false);
                
            }
            catch (Exception ex)
            {

                //throw new Exception("Algo salio mal ");
                MessageBox.Show("Algo salio mal: {0}",ex.Message);
            }
        }
        /// <summary>
        /// Permite realizar un aventa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarDatos();
            
            habilitar1(false);
        }
        /// <summary>
        /// Habilita  los botones para generar la venta 
        /// </summary>
        /// <param name="value"></param>
        private void habilitar1(bool value)
        {
            cmbDulce.IsEnabled = !value;
            cmbNoAsiento.IsEnabled = !value;
            cmbPelicula.IsEnabled = !value;
            cmbSala.IsEnabled = !value;
            txbTotalPagar.IsEnabled = !value;
            btnCalcularPagar.IsEnabled = !value;
            btnNuevo.IsEnabled = value;
            btnEliminar.IsEnabled = value;
            btnSalir.IsEnabled = !value;
            btnAceptar.IsEnabled = !value;
            
        }
        /// <summary>
        /// Permite limpiar datos
        /// </summary>
        private void LimpiarDatos()
        {
            cmbSala.Text = "";
            cmbDulce.Text = "";
            cmbPelicula.Text = "";
            txbCambio.Clear();
            txbRecibido.Clear();
            txbTotalPagar.Clear();
        }
        /// <summary>
        /// Eliminar Un estadistico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Estadisticos dul = dtgTabla.SelectedItem as Estadisticos;
            if (dul != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar esta venta", "Trabajo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorEstadisticos.Eliminar(dul.Id))
                    {
                        MessageBox.Show("ventae eliminada", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaVentas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la venta", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }
    }
}
