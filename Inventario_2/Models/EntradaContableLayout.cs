using System;
using System.Collections.Generic;

namespace Inventario_2.Models
{
    public class EntradaContableLayout
    {
        public string descripcion { get; set; }
        public int auxiliar { get; set; }
        public string fecha { get; set; }
        public double monto { get; set; }
        public int estado { get; set; }
        public int moneda { get; set; }
        public List<EntradaContableLayoutBody> transacciones { get; set; }
    }

    public class EntradaContableLayoutBody
    {
        public int cuenta { get; set; }
        public int tipoMovimiento { get; set; }
        public double monto { get; set; }
    }
}
