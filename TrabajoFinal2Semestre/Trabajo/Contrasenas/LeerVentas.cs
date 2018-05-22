using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo.Contrasenas
{
    class LeerVentas
    {
        ManejadorArchivos leerArchivo;
        ManejadorArchivos leerArchivo2;
        public LeerVentas()
        {
            leerArchivo = new ManejadorArchivos(@"C:\Trabajo6F\ContrasenaV.txt");
            leerArchivo2 = new ManejadorArchivos(@"C:\Trabajo6F\UsuarioV.txt");
        }
        string letras;
        /// <summary>
        /// Leer las contrasena
        /// </summary>
        /// <returns></returns>
        public string contrasena()
        {

            string datos = leerArchivo.LeerA();
            if (datos != null)
            {
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < 1; i++)
                {
                    string[] campos = lineas[i].Split(' ');
                    letras = campos[0];
                }
            }

            return letras;

        }
        string letrasUsu;
        /// <summary>
        /// Leer el usuario
        /// </summary>
        /// <returns></returns>
        public string usuario()
        {
            string datos = leerArchivo2.LeerA();
            if (datos != null)
            {
                string[] lineas = datos.Split('\n');
                for (int i = 0; i < 1; i++)
                {
                    string[] campos = lineas[i].Split(' ');
                    letrasUsu = campos[0];
                }
            }
            return letrasUsu;

        }
    }
}
