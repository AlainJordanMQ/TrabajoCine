using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo
{
    public class Generar
    {
        /// <summary>
        /// Permite generar un archivo que contiene usuario y contrasena
        /// </summary>
        /// <param name="usuario"> es el nombre de usuario</param>
        /// <param name="contrasena">es la contrasena</param>
        /// <returns></returns>
        public bool Genrar(string usuario, string contrasena)
        {

            try
            {
                StreamWriter archivo = new StreamWriter(@"C:\Trabajo6F\Usuario.txt");
                StreamWriter archivo2 = new StreamWriter(@"C:\Trabajo6F\Contrasena.txt");
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
