using System;
using System.Collections.Generic;
using System.Text;

namespace Trabajo.COMMON.Entidades
{
    public class NumeroSala: Base
    {
        public string Nombre { get; set; }
        public string CantidadAsientos { get; set; }
        public override string ToString()
        {
            return CantidadAsientos;
        }
    }
}
