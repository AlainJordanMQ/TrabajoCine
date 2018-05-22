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
    /// Lógica de interacción para IngresarPeliculas.xaml
    /// </summary>
    public partial class IngresarPeliculas : Window
    {
        enum accion
        {
            Nuevo,
            Editar
        }
        IManejadorPeliculas manejadorPeliculas;

        accion accionPeliculas;
        public IngresarPeliculas()
        {
            InitializeComponent();
            PonerBotonesPeliculasEnEdicion(false);
            LimpiarCamposDePeliculas();
            manejadorPeliculas = new ManejadorPeliculas(new RepositorioPeliculas());
            ActualizarTablaPeliculas();
        }
        /// <summary>
        /// Actualiza la tabla
        /// </summary>
        private void ActualizarTablaPeliculas()
        {
            dtgTabla.ItemsSource = null;
            dtgTabla.ItemsSource = manejadorPeliculas.Listar.OrderBy(p => p.FechaDeEstreno);
        }
        /// <summary>
        /// Limpia los campos
        /// </summary>
        private void LimpiarCamposDePeliculas()
        {
            txbCosto.Clear();
            txbDescripcion.Clear();
            txbNombre.Clear();
           
        }

        /// <summary>
        /// Pone los botones en bloqueo
        /// </summary>
        /// <param name="value">Verdadero o falso</param>
        private void PonerBotonesPeliculasEnEdicion(bool value)
        {
            btnCancelar.IsEnabled = value;
            btnGuardar.IsEnabled = value;
            btnNuevo.IsEnabled = !value;
            btnEditar.IsEnabled = !value;
            btnEliminar.IsEnabled = !value;

            txbCosto.IsEnabled = value;
            txbDescripcion.IsEnabled = value;
            txbNombre.IsEnabled = value;
            dtpFechaDeEstreno.IsEnabled = value; 
        }
        /// <summary>
        /// Ingresa una pelicula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDePeliculas();
            PonerBotonesPeliculasEnEdicion(true);
            accionPeliculas = accion.Nuevo;
        }
        /// <summary>
        /// Pemrite editar la pelicula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Peliculas pel = dtgTabla.SelectedItem as Peliculas;
            if (pel != null)
            {
                txbCosto.Text = pel.Costo;
                txbDescripcion.Text = pel.Descripcin;
                txbNombre.Text = pel.Nombre;
                dtpFechaDeEstreno.SelectedDate = pel.FechaDeEstreno;
                accionPeliculas = accion.Editar;
                PonerBotonesPeliculasEnEdicion(true);
            }

        }
        /// <summary>
        /// Permite guardar la pelicula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            if (accionPeliculas == accion.Nuevo)
            {
                if (VerificarCampos())
                {
                    if (Esnumero())
                    {
                        Peliculas pel = new Peliculas()
                        {
                            Nombre = txbNombre.Text,
                            Costo = txbCosto.Text,
                            Descripcin = txbDescripcion.Text,
                            FechaDeEstreno = dtpFechaDeEstreno.SelectedDate.Value

                        };
                        if (manejadorPeliculas.Agregar(pel))
                        {
                            MessageBox.Show("Pelicula agregada correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                            LimpiarCamposDePeliculas();
                            ActualizarTablaPeliculas();
                            PonerBotonesPeliculasEnEdicion(false);
                        }
                        else
                        {
                            MessageBox.Show("La Pelicula No se pudo agregar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {

                        MessageBox.Show("La Pelicula No se pudo agregar Eror campo de costo", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La Pelicula No se pudo agregar error campos", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (VerificarCampos())
                {
                    if (Esnumero())
                    {
                        Peliculas pel = dtgTabla.SelectedItem as Peliculas;
                        pel.Nombre = txbNombre.Text;
                        pel.Costo = txbCosto.Text;
                        pel.Descripcin = txbDescripcion.Text;
                        pel.FechaDeEstreno = dtpFechaDeEstreno.SelectedDate.Value;
                        if (manejadorPeliculas.Modificar(pel))
                        {
                            MessageBox.Show("Pelicula modificada correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                            LimpiarCamposDePeliculas();
                            ActualizarTablaPeliculas();
                            PonerBotonesPeliculasEnEdicion(false);
                        }
                        else
                        {
                            MessageBox.Show("La Pelicula No se pudo actualizar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }

            }
        }
        /// <summary>
        /// Evalua si es un numero
        /// </summary>
        /// <returns>Verdadero o falso</returns>
        private bool Esnumero()
        {
            int i = 0;
            string s = txbCosto.Text;
            bool result;
            //throw new NotImplementedException();
            return result = int.TryParse(s, out i); //i now = 108  
        }
        /// <summary>
        /// Verifica que los campos esten llenos
        /// </summary>
        /// <returns>Verdadero o falso</returns>
        private bool VerificarCampos()
        {
            if (txbCosto.Text != "" && txbDescripcion.Text != "" && txbNombre.Text != "" && dtpFechaDeEstreno.SelectedDate!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Cancela la pelicula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDePeliculas();
            PonerBotonesPeliculasEnEdicion(false);
        }
        /// <summary>
        /// Elimina la pelicula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Peliculas pel = dtgTabla.SelectedItem as Peliculas;
            if (pel != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar esta pelicula", "Trabajo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorPeliculas.Eliminar(pel.Id))
                    {
                        MessageBox.Show("Pelicula eliminada", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaPeliculas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la pelicula", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        /// <summary>
        /// Permite salir de la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            IngresarPeliculas v = new IngresarPeliculas();
            this.Close();
        }

        private void btnExportar_Click(object sender, RoutedEventArgs e)
        {
            dtgTabla.SelectAllCells();
            dtgTabla.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, dtgTabla);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            dtgTabla.UnselectAllCells();
            System.IO.StreamWriter file1 = new System.IO.StreamWriter(@"C:\Trabajo6F/TrabajoPeliculas.xls");
            file1.WriteLine(result.Replace(',', ' '));
            file1.Close();
            MessageBox.Show("Se exporto", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
