using System;
using System.Collections.Generic;
using System.Text;

namespace Trabajo.COMMON.Entidades
{
    public class Peliculas:Base
    {
        public string Nombre { get; set; }
        //public string Duracion { get; set; }
        public string Costo { get; set; }
        public string Descripcin { get; set; }
        public DateTime FechaDeEstreno { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
