using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Lógica de interacción para IngresarDuldes.xaml
    /// </summary>
    public partial class IngresarDuldes : Window
    {
        enum accion
        {
            Nuevo,
            Editar
        }
        IManejadorDulces manejadorDulces;

        accion accionDulces;
        public IngresarDuldes()
        {
            InitializeComponent();
            PonerBotonesDulcesEnEdicion(false);
            LimpiarCamposDeDulces();
            manejadorDulces = new ManejadorDulces(new RepopsitorioDulces());
            ActualizarTablaDulces();
        }
        /// <summary>
        /// Actualiza la tabla
        /// </summary>
        private void ActualizarTablaDulces()
        {
            dtgDulces.ItemsSource = null;
            dtgDulces.ItemsSource = manejadorDulces.Listar.OrderBy(p=>p.Nomnbre);
        }
        /// <summary>
        /// Permite limpiar los campos
        /// </summary>
        private void LimpiarCamposDeDulces()
        {
            txbCostoDulce.Clear();
            txbDescripcion.Clear();
            txbNombreDulce.Clear();
        }
        /// <summary>
        /// Bloque los botones
        /// </summary>
        /// <param name="value">Recibe un verdadero o un falso</param>

        private void PonerBotonesDulcesEnEdicion(bool value)
        {
            btnCancelar.IsEnabled = value;
            btnGuardar.IsEnabled = value;
            btnNuevo.IsEnabled = !value;
            btnEditar.IsEnabled = !value;
            btnEliminar.IsEnabled = !value;

            txbCostoDulce.IsEnabled = value;
            txbNombreDulce.IsEnabled = value;
            txbDescripcion.IsEnabled = value;
            txbCostoDulce.IsEnabled = value;
            txbCargarFoto.IsEnabled = value;
        }
        /// <summary>
        /// Permite ingresar un nuevo dulce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeDulces();
            PonerBotonesDulcesEnEdicion(true);
            accionDulces = accion.Nuevo;
        }

        /// <summary>
        /// Permite editar un dulce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Dulces dul = dtgDulces.SelectedItem as Dulces;
            if (dul != null)
            {
                txbCostoDulce.Text = dul.Costo;
                txbDescripcion.Text = dul.Descripcion;
                txbNombreDulce.Text = dul.Nomnbre;
                imgFoto.Source = ByteToImage(dul.Fotografia);
                accionDulces = accion.Editar;
                PonerBotonesDulcesEnEdicion(true);
            }
        }
        /// <summary>
        /// Permite cargar una imagen
        /// </summary>
        /// <param name="imageData">Un arreglo de byte</param>
        /// <returns></returns>

        private ImageSource ByteToImage(byte[] imageData)
        {
            if(imageData == null)
            {
                return null;
            }
            else
            {
                BitmapImage biImg = new BitmapImage();
                MemoryStream ms = new MemoryStream(imageData);
                biImg.BeginInit();
                biImg.StreamSource = ms;
                biImg.EndInit();
                ImageSource imgSrc = biImg as ImageSource;
                return imgSrc;
            }
        }
        /// <summary>
        /// Permite guardar un dulce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (accionDulces == accion.Nuevo)
            {
                if (VerificarCampos())
                {
                    if (Esnumero())
                    {
                        Dulces dul = new Dulces()
                        {
                            Nomnbre = txbNombreDulce.Text,
                            Costo = txbCostoDulce.Text,
                            Descripcion = txbDescripcion.Text,
                            Fotografia = ImageToByte(imgFoto.Source)

                        };
                        if (manejadorDulces.Agregar(dul))
                        {
                            MessageBox.Show("Dulce agregado correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                            LimpiarCamposDeDulces();
                            ActualizarTablaDulces();
                            PonerBotonesDulcesEnEdicion(false);
                        }
                        else
                        {
                            MessageBox.Show("El Dulce No se pudo agregar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {

                        MessageBox.Show("El Dulce No se pudo agregar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El Dulce No se pudo agregar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (VerificarCampos())
                {
                    if (Esnumero())
                    {
                        Dulces dul = dtgDulces.SelectedItem as Dulces;
                        dul.Nomnbre = txbNombreDulce.Text;
                        dul.Costo = txbCostoDulce.Text;
                        dul.Descripcion = txbDescripcion.Text;
                        dul.Fotografia = ImageToByte(imgFoto.Source);
                        if (manejadorDulces.Modificar(dul))
                        {
                            MessageBox.Show("Dulce modificado correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                            LimpiarCamposDeDulces();
                            ActualizarTablaDulces();
                            PonerBotonesDulcesEnEdicion(false);
                        }
                        else
                        {
                            MessageBox.Show("El Dulce No se pudo actualizar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El Dulce No se pudo agregar error en costo", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                else
                {
                    MessageBox.Show("El Dulce No se pudo agregar Error campos", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                }


            }
        }
        /// <summary>
        /// Verifica que todos los campos esten llenos
        /// </summary>
        /// <returns>un verdadero o un falso</returns>

        private bool VerificarCampos()
        {
            if (txbCostoDulce.Text!="" && txbDescripcion.Text!="" && txbNombreDulce.Text!="")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Permite saber si el dato es un numero o no
        /// </summary>
        /// <returns>verdadero o falso</returns>

        private bool Esnumero()
        {
            int i = 0;
            string s = txbCostoDulce.Text;
            bool result;
            //throw new NotImplementedException();
            return result = int.TryParse(s, out i); //i now = 108  
        }
        /// <summary>
        /// Carga una imagen
        /// </summary>
        /// <param name="image"> Lee la imagen</param>
        /// <returns>La imagen</returns>

        private byte[] ImageToByte(ImageSource image)
        {
            if (image != null)
            {
                MemoryStream memstream = new MemoryStream();
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image as BitmapSource));
                encoder.Save(memstream);
                return memstream.ToArray();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Cancela la accion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeDulces();
            PonerBotonesDulcesEnEdicion(false);
        }

        /// <summary>
        /// Elimina un dulce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Dulces dul = dtgDulces.SelectedItem as Dulces;
            if (dul != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar este Dulce", "Trabajo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorDulces.Eliminar(dul.Id))
                    {
                        MessageBox.Show("Dulce eliminado", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaDulces();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Dulce", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }
        /// <summary>
        /// Permite cargar una foto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbCargarFoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Title = "selecciona una imagen";
            dialogo.Filter = "Archivo de imagen|*.jpg; *.png";
            if (dialogo.ShowDialog().Value)
            {
                imgFoto.Source = new BitmapImage(new Uri(dialogo.FileName));
            }
        }
        /// <summary>
        /// Permite salir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            IngresarDuldes v = new IngresarDuldes();
            this.Close();
        }
    }
}
