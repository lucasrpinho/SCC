using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Pedidos
    {
        public int vendedor { get; set; }
        public DateTime data { get; set; }
        public double valor { get; set; }

        public Pedidos(int vendedor, DateTime data, double valor)
        {
            this.vendedor = vendedor;
            this.data = data;
            this.valor = valor;
        }

        public Pedidos()
        {

        }
    }    
}
