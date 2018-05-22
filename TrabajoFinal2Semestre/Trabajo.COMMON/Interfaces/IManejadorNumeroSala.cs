using System;
using System.Collections.Generic;
using System.Text;
using Trabajo.COMMON.Entidades;

namespace Trabajo.COMMON.Interfaces
{
    public interface IManejadorNumeroSala : IManejadorGenerico<NumeroSala>
    {
        List<NumeroSala> Salas(string Sala);
    }
}
