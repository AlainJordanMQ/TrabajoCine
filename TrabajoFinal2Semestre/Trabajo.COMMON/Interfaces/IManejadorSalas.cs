using System;
using System.Collections.Generic;
using System.Text;
using Trabajo.COMMON.Entidades;

namespace Trabajo.COMMON.Interfaces
{
    public interface IManejadorSalas : IManejadorGenerico<Salas>
    {
        List<Salas> Salas (string Sala);
    }
}
