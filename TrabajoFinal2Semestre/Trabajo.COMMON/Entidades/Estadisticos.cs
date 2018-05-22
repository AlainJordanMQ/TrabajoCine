using System;
using System.Collections.Generic;
using System.Text;

namespace Trabajo.COMMON.Entidades
{
    public class Estadisticos: Base
    {
        public string NombrePelicula { get; set; }
        public string CantidadDeBoletos { get; set; }
        public string Costo { get; set; }
        public override string ToString()
        {
            return CantidadDeBoletos;
        }
    }
}
