using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabajo.COMMON.Entidades;
using Trabajo.COMMON.Interfaces;

namespace Trabajo.BIZ
{
    public class ManejadorPeliculas: IManejadorPeliculas
    {
        IRepositorio<Peliculas> repositorio;
        public ManejadorPeliculas(IRepositorio<Peliculas> repo)
        {
            repositorio = repo;

        }

        public List<Peliculas> Listar => repositorio.Read;
        /// <summary>
        /// Es un metodo para agregar una nueva pelicula
        /// </summary>
        /// <param name="entidad">Es la pelicula que se pretende agregar</param>
        /// <returns>regresa la pelicula que se desea agregar</returns>

        public bool Agregar(Peliculas entidad)
        {
            return repositorio.Create(entidad);
        }

        /// <summary>
        /// Me permite buscar entre todas las peliculas
        /// </summary>
        /// <param name="id">es la clave de la entidad selecionada</param>
        /// <returns>me regresa un alista de las peliculas que existen</returns>

        public Peliculas BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }
        /// <summary>
        /// Me permite eliminar una pelicula 
        /// </summary>
        /// <param name="id">Es la clave con la que identifico a una pelicula</param>
        /// <returns>la entidad eliminada</returns>

        public bool Eliminar(string id)
        {
            return repositorio.Delete(id);
        }
        /// <summary>
        /// Me permite cambiar los datos de una pelicula
        /// </summary>
        /// <param name="entidad">Es la pelicula que se desea modificar</param>
        /// <returns> la pelicula que se cambiara</returns>

        public bool Modificar(Peliculas entidad)
        {
            return repositorio.Update(entidad);
        }
        /// <summary>
        /// Obtengo una lista de Peliculas 
        /// </summary>
        /// <param name="nombre">es el nombre con el cual se guardo la pelicula</param>
        /// <returns>Obtengo el nombre de la pelicula</returns>

        public List<Peliculas> Pelicula(string nombre)
        {
            return Listar.Where(e => e.Nombre == nombre).ToList();


        }
    }
}
