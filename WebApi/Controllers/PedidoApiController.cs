using System.Collections.Generic;
using System.Web.Http;
using WebApi.Business;
using WebApi.Business.Negocio;

namespace WebApi.Controllers
{
    public class PedidoApiController : ApiController
    {
        PedidoBusiness pedidoBusiness;
        public PedidoApiController()
        {
            this.pedidoBusiness = new PedidoBusiness();
        }
        
        [HttpGet]
        public List<DropModel> Pessoa()
        {
            return pedidoBusiness.Clientes();
        }

        [HttpPost]
        public string Pedido([FromBody]InserirPedidosModel dadosPedido)
        {
            return pedidoBusiness.InserirPedidos(dadosPedido);
        }

        [HttpGet]
        public List<RetornoPedidosModel> Pedido(string numero, int? idPessoa)
        {
            return pedidoBusiness.BuscarPedidos(numero,idPessoa);
        }
    }
}
