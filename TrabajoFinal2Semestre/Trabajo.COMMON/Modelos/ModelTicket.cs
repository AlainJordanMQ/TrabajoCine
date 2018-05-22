using System;
using System.Collections.Generic;
using System.Text;
using Trabajo.COMMON.Entidades;

namespace Trabajo.COMMON.Modelos
{
    public class ModelTicket
    {
       
        public string Nombre { get; set; }
        public string CantidadDeBoletos { get; set; }
        
        public ModelTicket(Estadisticos estadisticos)
        {
            
            Nombre = string.Format( "{0}", estadisticos.NombrePelicula);
            CantidadDeBoletos = string.Format( "{0}", estadisticos.CantidadDeBoletos);
        }
    }
}
