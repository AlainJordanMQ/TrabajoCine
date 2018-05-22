using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabajo.COMMON.Entidades;
using Trabajo.COMMON.Interfaces;

namespace Trabajo.BIZ
{
    public class ManejadorEstadisticos : IManejadorEstadiscos
    {
        IRepositorio<Estadisticos> repositorio;
        public ManejadorEstadisticos(IRepositorio<Estadisticos> repo)
        {
            repositorio = repo;

        }
        /// <summary>
        /// Listar los estadisticos
        /// </summary>
        public List<Estadisticos> Listar => repositorio.Read;
        /// <summary>
        ///  Es un metodo para agregar un nuevo estadistico
        /// </summary>
        /// <param name="entidad">Es el estadistico que se pretende agregar</param>
        /// <returns>regresa el dulce que se desea agregar</returns>

        public bool Agregar(Estadisticos entidad)
        {
            return repositorio.Create(entidad);
        }
        /// <summary>
        /// Me permite buscar entre todos los estadisticos
        /// </summary>
        /// <param name="id">es la clave de la entidad selecionada</param>
        /// <returns>me regresa un alista de los estadisticos que existen</returns>

        public Estadisticos BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }
        /// <summary>
        /// Me permite eliminar un estadistico 
        /// </summary>
        /// <param name="id">Es la clave con la que identifico a un estadistico</param>
        /// <returns>la entidad eliminada</returns>

        public bool Eliminar(string id)
        {
            return repositorio.Delete(id);
        }
        /// <summary>
        /// Me permite cambiar los datos de un estadistico
        /// </summary>
        /// <param name="entidad">Es el estadistico que se desea modificar</param>
        /// <returns> el estadistico que se cambiara</returns>

        public bool Modificar(Estadisticos entidad)
        {
            return repositorio.Update(entidad);
        }
        /// <summary>
        /// Obtengo una lista de estadisticos
        /// </summary>
        /// <param name="nombre">es el nombre con el cual se guardo el estadistico</param>
        /// <returns>Obtengo el valor de al cantidad de boletos</returns>

        public List<Estadisticos> Pelicula(string nombre)
        {
            return Listar.Where(e => e.NombrePelicula == nombre).ToList();


        }
    }
}
