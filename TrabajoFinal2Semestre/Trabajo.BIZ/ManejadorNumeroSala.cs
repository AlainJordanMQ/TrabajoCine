using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabajo.COMMON.Entidades;
using Trabajo.COMMON.Interfaces;

namespace Trabajo.BIZ
{
    public class ManejadorNumeroSala : IManejadorNumeroSala
    {
        IRepositorio<NumeroSala> repositorio;
        public ManejadorNumeroSala(IRepositorio<NumeroSala> repo)
        {
            repositorio = repo;

        }

        public List<NumeroSala> Listar => repositorio.Read;
        /// <summary>
        /// Es un metodo para agregar un nuevo numero de salas
        /// </summary>
        /// <param name="entidad">Es el numero de salas que se pretende agregar</param>
        /// <returns>regresa el numero de salas que se desea agregar</returns>

        public bool Agregar(NumeroSala entidad)
        {
            return repositorio.Create(entidad);
        }
        /// <summary>
        /// Me permite buscar entre todos lo nuemeros de salas
        /// </summary>
        /// <param name="id">es la clave de la entidad selecionada</param>
        /// <returns>me regresa un alista de los numeros de salas que existen</returns>

        public NumeroSala BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }
        /// <summary>
        /// Me permite eliminar un numero de sala 
        /// </summary>
        /// <param name="id">Es la clave con la que identifico a un numero de sala</param>
        /// <returns>la entidad eliminada</returns>

        public bool Eliminar(string id)
        {
            return repositorio.Delete(id);
        }
        /// <summary>
        /// Me permite cambiar los datos de un numero de sala
        /// </summary>
        /// <param name="entidad">Es el numero de sala que se desea modificar</param>
        /// <returns> el numero de sala que se cambiara</returns>

        public bool Modificar(NumeroSala entidad)
        {
            return repositorio.Update(entidad);
        }
        /// <summary>
        /// Obtengo una lista de numero de salas 
        /// </summary>
        /// <param name="nombre">es el nombre con el cual se guardo el numero de sala</param>
        /// <returns>Obtengo el nuemro de salas</returns>

        public List<NumeroSala> Salas(string sala)
        {
            return Listar.Where(e => e.Nombre == sala).ToList();

        }
    }
}
