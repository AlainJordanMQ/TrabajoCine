using System;
using System.Collections.Generic;
using System.Text;
using Trabajo.COMMON.Entidades;

namespace Trabajo.COMMON.Interfaces
{
    public interface IManejadorPeliculas : IManejadorGenerico<Peliculas>
    {
        List<Peliculas> Pelicula(string pelicula);
    }
}
