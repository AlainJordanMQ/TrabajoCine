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
        }

        private void ActualizarTablaVentas()
        {
            dtgTabla.ItemsSource = null;
            dtgTabla.ItemsSource = manejadorEstadisticos.Listar;//.OrderBy(p => p.FechaDeEstreno);
        }

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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (estadisticos == accion.Nuevo)
            {
                Estadisticos est = new Estadisticos()
                {
                    NombrePelicula = cmbPelicula.Text,
                    CantidadDeBoletos = "1"
                   

                };
                if (manejadorEstadisticos.Agregar(est))
                {
                    MessageBox.Show("Venta agregada correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    
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
        double cambio;
        private void txbCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (VerificarCampos())
            {
                if (Esnumero())
                {
                    cambio = (double.Parse(txbRecibido.Text) - CostoFinal);
                    if (cambio >= 0)
                    {
                        txbCambio.Text = cambio.ToString();
                        MessageBox.Show("Operacion generada correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private bool VerificarCampos()
        {
            if (txbRecibido.Text != "" && cmbDulce.SelectedItem !=null  && txbNombre.Text != "" && cmbPelicula.SelectedItem != null && cmbSala.SelectedItem != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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
        private void btnCalcularPagar_Click(object sender, RoutedEventArgs e)
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
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            VentaBoletos v = new VentaBoletos();
            this.Close();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            VentaBoletos v = new VentaBoletos();
            this.Close();
        }
    }
}
