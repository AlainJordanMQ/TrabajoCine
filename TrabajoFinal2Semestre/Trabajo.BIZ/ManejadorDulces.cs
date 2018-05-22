using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabajo.COMMON.Entidades;
using Trabajo.COMMON.Interfaces;

namespace Trabajo.BIZ
{
    public class ManejadorDulces: IManejadorDulces
    {
        IRepositorio<Dulces> repositorio;
        public ManejadorDulces(IRepositorio<Dulces> repo)
        {
            repositorio = repo;

        }

        public List<Dulces> Listar => repositorio.Read;
        /// <summary>
        /// Es un metodo para agregar un nuevo dulce
        /// </summary>
        /// <param name="entidad">Es el dulce que se pretende agregar</param>
        /// <returns>regresa el dulce que se desea agregar</returns>

        public bool Agregar(Dulces entidad)
        {
            return repositorio.Create(entidad);
        }
        /// <summary>
        /// Me permite buscar entre todos lo dulces
        /// </summary>
        /// <param name="id">es la clave de la entidad selecionada</param>
        /// <returns>me regresa un alista de los dulces que existen</returns>

        public Dulces BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }
        /// <summary>
        /// Me permite eliminar un dulce 
        /// </summary>
        /// <param name="id">Es la clave con la que identifico a un dulce</param>
        /// <returns>la entidad eliminada</returns>

        public bool Eliminar(string id)
        {
            return repositorio.Delete(id);
        }
        /// <summary>
        /// Me permite cambiar los datos de un dulce
        /// </summary>
        /// <param name="entidad">Es el dulce que se desea modificar</param>
        /// <returns> el dulce que se cambiara</returns>

        public bool Modificar(Dulces entidad)
        {
            return repositorio.Update(entidad);
        }
        /// <summary>
        /// Obtengo una lista de dulces 
        /// </summary>
        /// <param name="nombre">es el nombre con el cual se guardo el dulce</param>
        /// <returns>Obtengo el valor del dulce</returns>

        public List<Dulces> Precio(string nombre)
        {
            return Listar.Where(e => e.Nomnbre == nombre).ToList();
           

        }
    }
}
