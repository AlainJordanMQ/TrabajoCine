
using System;
using System.Collections.Generic;
using System.Text;

namespace Trabajo.COMMON.Entidades
{
    public class Dulces:Base
    {
        public string Nomnbre { get; set; }
        public string Costo { get; set; }
        public string Descripcion { get; set; }
        public byte[] Fotografia { get; set; }

        public override string ToString()
        {
            return Nomnbre;
        }
    }
}
