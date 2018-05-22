using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo.Contrasenas
{
    public class GenerarEstadis
    {
        /// <summary>
        /// Permite generar los usuario y contrasena
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasena"></param>
        /// <returns></returns>
        public bool Genrar(string usuario, string contrasena)
        {

            try
            {
                StreamWriter archivo = new StreamWriter(@"C:\Trabajo6F\UsuarioE.txt");
                StreamWriter archivo2 = new StreamWriter(@"C:\Trabajo6F\ContrasenaE.txt");
                archivo.Write("{0}", usuario);
                archivo2.Write("{0}", contrasena);
                archivo.Close();
                archivo2.Close();
                return true;
            }



            catch (Exception)
            {
                return false;
            }
        }
    }
}
