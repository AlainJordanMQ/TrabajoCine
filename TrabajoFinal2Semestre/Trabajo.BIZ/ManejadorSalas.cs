using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabajo.COMMON.Entidades;
using Trabajo.COMMON.Interfaces;

namespace Trabajo.BIZ
{
    public class ManejadorSalas : IManejadorSalas
    {
        IRepositorio<Salas> repositorio;
        public ManejadorSalas(IRepositorio<Salas> repo)
        {
            repositorio = repo;

        }

        public List<Salas> Listar => repositorio.Read;
        /// <summary>
        /// Es un metodo para agregar una nueva sala
        /// </summary>
        /// <param name="entidad">Es la sala que se pretende agregar</param>
        /// <returns>regresa la sala que se desea agregar</returns>

        public bool Agregar(Salas entidad)
        {
            return repositorio.Create(entidad);
        }
        /// <summary>
        /// Me permite buscar entre todas las salas
        /// </summary>
        /// <param name="id">es la clave de la entidad selecionada</param>
        /// <returns>me regresa un alista de las salas que existen</returns>

        public Salas BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }
        /// <summary>
        /// Me permite eliminar una sala 
        /// </summary>
        /// <param name="id">Es la clave con la que identifico a una sala</param>
        /// <returns>la entidad eliminada</returns>

        public bool Eliminar(string id)
        {
            return repositorio.Delete(id);
        }
        /// <summary>
        /// Me permite cambiar los datos de una sala
        /// </summary>
        /// <param name="entidad">Es ela sala que se desea modificar</param>
        /// <returns> la sala que se cambiara</returns>

        public bool Modificar(Salas entidad)
        {
            return repositorio.Update(entidad);
        }
        /// <summary>
        /// Obtengo una lista de salas 
        /// </summary>
        /// <param name="nombre">es el nombre con el cual se guardo la sala</param>
        /// <returns>Obtengo el valor del la sala</returns>

        public List<Salas> Salas(string sala)
        {
            return Listar.Where(e => e.Nombre == sala).ToList();
           
        }
    }
}
