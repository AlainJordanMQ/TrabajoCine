using System;
using System.Collections.Generic;
using System.Text;
using Trabajo.COMMON.Entidades;

namespace Trabajo.COMMON.Interfaces
{
   public  interface IManejadorCostoFinal : IManejadorGenerico<CostoFinal>
    {
        List<CostoFinal> Pelicula(string pelicula);
    }
}
