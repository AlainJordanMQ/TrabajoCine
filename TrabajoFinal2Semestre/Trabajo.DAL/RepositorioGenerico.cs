using System;
using System.Collections.Generic;
using System.Text;
using Trabajo.COMMON.Entidades;
using Trabajo.COMMON.Interfaces;

namespace Trabajo.DAL
{
    public class RepositorioGenerico//<T> : IRepositorio<T> where T : Base
    {/*
        private string DBName = "Trabajo.db";
        private string TableName = "Dulces";

        public List<T> Read
        {
            get
            {
                List<T> datos = new List<T>();
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<T>(TableName).FindAll().ToList();
                }
                return datos;
            }

        }

        public bool Create(T entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<T>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                int r;
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<T>(TableName);
                    r = coleccion.Delete(e => e.Id == id);
                }
                return r > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(T entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<T>(TableName);
                    coleccion.Update(entidadModificada);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }*/
    }
}
