using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Business
{
    public class RetornoPedidosModel
    {
        public int UUId { get; set; }
        public string Pessoa { get; set; }

        public int Numero { get; set; }

        public double Total { get; set; }
    }
}
