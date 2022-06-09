using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Comissao    {     
        
        public int vendedor { get; set; }
        public int mes { get; set; }
        public double valor { get; set; }

        public Comissao(int v, int m, double val )
        {

            this.vendedor = v;
            this.mes = m;
            this.valor = val;
        }

        public Comissao()
        {

        }
    }
}
