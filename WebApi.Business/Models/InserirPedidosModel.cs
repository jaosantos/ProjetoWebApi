using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Business
{
    public class InserirPedidosModel
    {
        public int PessoaId { get; set; }
        public List<ItensPedidoModel> ListaItens { get; set; }
    }

    public class ItensPedidoModel
    {
        public int ProdutoId { get; set; }
        public double Qtd { get; set; }
        public double PercentualDesconto { get; set; }
    }
}
