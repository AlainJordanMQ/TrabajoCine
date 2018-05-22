using System;
using System.Collections.Generic;
using System.Text;
using Trabajo.COMMON.Entidades;

namespace Trabajo.COMMON.Interfaces
{
    public interface IManejadorDulces : IManejadorGenerico<Dulces>
    {
        List<Dulces> Precio(string nombre);
    }
}
