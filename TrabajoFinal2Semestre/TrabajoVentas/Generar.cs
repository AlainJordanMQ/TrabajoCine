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
        public bool Genrar(string usuario, string contrasena)
        {

            try
            {
                StreamWriter archivo = new StreamWriter("Usuario.txt");
                StreamWriter archivo2 = new StreamWriter("Contrasena.txt");
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
