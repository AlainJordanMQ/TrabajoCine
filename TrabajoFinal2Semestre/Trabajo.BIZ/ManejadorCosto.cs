using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabajo.COMMON.Entidades;
using Trabajo.COMMON.Interfaces;

namespace Trabajo.BIZ
{
    public class ManejadorCosto: IManejadorCostoFinal
    {
        IRepositorio<CostoFinal> repositorio;
        public ManejadorCosto(IRepositorio<CostoFinal> repo)
        {
            repositorio = repo;

        }

        public List<CostoFinal> Listar => repositorio.Read;
        /// <summary>
        /// Es un metodo para agregar un costo
        /// </summary>
        /// <param name="entidad">Es el costo que se pretende agregar</param>
        /// <returns>regresa el costo que se desea agregar</returns>
        public bool Agregar(CostoFinal entidad)
        {
            return repositorio.Create(entidad);
        }
        /// <summary>
        /// Me permite buscar entre todos lo dulces
        /// </summary>
        /// <param name="id">es la clave de la entidad selecionada</param>
        /// <returns>me regresa un alista de los costos que existen</returns>

        public CostoFinal BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }
        /// <summary>
        /// Me permite eliminar un dulce 
        /// </summary>
        /// <param name="id">Es la clave con la que identifico a un costo</param>
        /// <returns>la entidad eliminada</returns>

        public bool Eliminar(string id)
        {
            return repositorio.Delete(id);
        }
        /// <summary>
        /// Me permite cambiar los datos de un dulce
        /// </summary>
        /// <param name="entidad">Es el costo que se desea modificar</param>
        /// <returns> el costo que se cambiara</returns>

        public bool Modificar(CostoFinal entidad)
        {
            return repositorio.Update(entidad);

        }
        public List<CostoFinal> Pelicula(string nombre)
        {
            return Listar.Where(e => e.NombrePelicula == nombre).ToList();


        }
    }

}
