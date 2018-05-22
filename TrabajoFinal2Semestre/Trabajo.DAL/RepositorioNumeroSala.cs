using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabajo.COMMON.Entidades;
using Trabajo.COMMON.Interfaces;

namespace Trabajo.DAL
{
   public  class RepositorioNumeroSala : IRepositorio<NumeroSala>
    {
        private string DBName = "Trabajo.db";
        private string TableName = "Salas";

        /// <summary>
        /// Permite leer la entidad
        /// </summary>
        public List<NumeroSala> Read
        {
            get
            {
                List<NumeroSala> datos = new List<NumeroSala>();
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<NumeroSala>(TableName).FindAll().ToList();
                }
                return datos;
            }

        }

        /// <summary>
        /// Permite crear una  entidad
        /// </summary>
        /// <param name="entidad">leyendo el nombre</param>
        /// <returns> un falso o verdadero</returns>
        public bool Create(NumeroSala entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<NumeroSala>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// Me permite eliminar
        /// </summary>
        /// <param name="id">Es la clave de la entidad</param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            try
            {
                int r;
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<NumeroSala>(TableName);
                    r = coleccion.Delete(e => e.Id == id);
                }
                return r > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// Me permite eliminar
        /// </summary>
        /// <param name="entidadModificada"> La entidad que se desea cambiar</param>
        /// <returns>Verdadero o falso</returns>
        public bool Update(NumeroSala entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<NumeroSala>(TableName);
                    coleccion.Update(entidadModificada);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
