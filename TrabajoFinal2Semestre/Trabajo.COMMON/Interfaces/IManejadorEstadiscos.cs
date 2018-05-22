using System;
using System.Collections.Generic;
using System.Text;
using Trabajo.COMMON.Entidades;

namespace Trabajo.COMMON.Interfaces
{
    public interface IManejadorEstadiscos : IManejadorGenerico<Estadisticos>
    {
        List<Estadisticos> Pelicula(string pelicula);
    }
}
