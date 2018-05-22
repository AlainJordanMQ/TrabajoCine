using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo
{
    public class ManejadorArchivos
    {

        public string Archivo { get; set; }
        public ManejadorArchivos(string archivo)
        {
            Archivo = archivo;
        }
        /// <summary>
        /// Permite leer
        /// </summary>
        /// <returns></returns>
        public string LeerA()
        {
            try
            {
                StreamReader file = new StreamReader(Archivo);
                string datos = file.ReadToEnd();
                file.Close();
                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
