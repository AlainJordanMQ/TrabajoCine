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
    /// Lógica de interacción para VentanaSalas.xaml
    /// </summary>
    public partial class VentanaSalas : Window
    {
        enum accion
        {
            Nuevo,
            Editar
        }
        IManejadorSalas manejadorSalas;

        accion accionSalas;
        public VentanaSalas()
        {
            InitializeComponent();
            PonerBotonesSalasEnEdicion(false);
            LimpiarCamposDeSalas();
            manejadorSalas = new ManejadorSalas(new RepositorioSalas());
            ActualizarTablaSalas();
        }
        /// <summary>
        /// Actualiza la tabla
        /// </summary>
        private void ActualizarTablaSalas()
        {
            dtgTabla.ItemsSource = null;
            dtgTabla.ItemsSource = manejadorSalas.Listar.OrderBy(p => p.Nombre);
        }
        /// <summary>
        /// Limpia los campos
        /// </summary>
        private void LimpiarCamposDeSalas()
        {
            txbCantidadAsientos.Clear();
            
            txbNombre.Clear();
        }
        /// <summary>
        /// Pone slo botones en modo edicion
        /// </summary>
        /// <param name="value">Un verdadero o falso</param>
        private void PonerBotonesSalasEnEdicion(bool value)
        {
            btnCancelar.IsEnabled = value;
            btnGuardar.IsEnabled = value;
            btnNuevo.IsEnabled = !value;
            btnEditar.IsEnabled = !value;
            btnEliminar.IsEnabled = !value;

            txbCantidadAsientos.IsEnabled = value;
          
            txbNombre.IsEnabled = value;
         
        }
        /// <summary>
        /// Permite ingresar una sala nueva
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeSalas();
            PonerBotonesSalasEnEdicion(true);
            accionSalas = accion.Nuevo;
        }
        /// <summary>
        /// Permite editar una sala
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Salas sal = dtgTabla.SelectedItem as Salas;
            if (sal != null)
            {
                txbCantidadAsientos.Text = sal.CantidadAsientos;
                
                txbNombre.Text = sal.Nombre;
               
                accionSalas = accion.Editar;
                PonerBotonesSalasEnEdicion(true);
            }
        }
        /// <summary>
        /// Permite guaradar una sala
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (accionSalas == accion.Nuevo)
            {
                if (VerificarCampos())
                {
                    if (Esnumero())
                    {
                        Salas sal = new Salas()
                        {
                            Nombre = txbNombre.Text,
                            CantidadAsientos = txbCantidadAsientos.Text,
                            

                        };
                        if (manejadorSalas.Agregar(sal))
                        {
                            MessageBox.Show("Sala agregada correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                            LimpiarCamposDeSalas();
                            ActualizarTablaSalas();
                            PonerBotonesSalasEnEdicion(false);
                        }
                        else
                        {
                            MessageBox.Show("La Sala No se pudo agregar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {

                        MessageBox.Show("La Sala No se pudo agregar Error ", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La Sala No se pudo agregar Error campos", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (VerificarCampos())
                {
                    if (Esnumero())
                    {
                        Salas sal = dtgTabla.SelectedItem as Salas;
                        sal.Nombre = txbNombre.Text;
                        sal.CantidadAsientos = txbCantidadAsientos.Text;

                        if (manejadorSalas.Modificar(sal))
                        {
                            MessageBox.Show("Sala modificada correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                            LimpiarCamposDeSalas();
                            ActualizarTablaSalas();
                            PonerBotonesSalasEnEdicion(false);
                        }
                        else
                        {
                            MessageBox.Show("La Sala No se pudo actualizar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Evalua si es numero
        /// </summary>
        /// <returns></returns>
        private bool Esnumero()
        {
            int i = 0;
            string s = txbCantidadAsientos.Text;
            bool result;
            //throw new NotImplementedException();
            return result = int.TryParse(s, out i); //i now = 108  
        }

        /// <summary>
        /// Verifica que los campos estan llenos
        /// </summary>
        /// <returns></returns>
        private bool VerificarCampos()
        {
            if (txbCantidadAsientos.Text != "" && txbNombre.Text != ""  )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Permite cancelar una sala
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeSalas();
            PonerBotonesSalasEnEdicion(false);
        }
        /// <summary>
        /// permite eliminar un asala
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Salas sal = dtgTabla.SelectedItem as Salas;
            if (sal != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar esta Sala", "Trabajo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorSalas.Eliminar(sal.Id))
                    {
                        MessageBox.Show("Sala eliminada", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaSalas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la Sala", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }
        /// <summary>
        /// Permite salir 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            VentanaSalas v = new VentanaSalas();
            this.Close();
        }
    }
}
