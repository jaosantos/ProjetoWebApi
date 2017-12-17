using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.Repositorio;
using WebApi.Entidade.Entidades;

namespace WebApi.Business.Negocio
{
    public class PedidoBusiness
    {
        IRepository<Pedido> repositorioPedido;
        IRepository<ItemPedido> repositorioItemPedido;
        IRepository<Produto> repositorioProduto;
        IRepository<Pessoa> repositorioPessoa;
        public PedidoBusiness()
        {
            repositorioPedido = new Repository<Pedido>();
            repositorioItemPedido = new Repository<ItemPedido>();
            repositorioProduto = new Repository<Produto>();
            repositorioPessoa = new Repository<Pessoa>();
        }

        public string InserirPedidos(InserirPedidosModel dadosPedido)
        {
            try
            {
                if (dadosPedido != null)
                {
                    var pedido = new Pedido();
                    pedido.PessoaId = dadosPedido.PessoaId;
                    pedido.DataEmissao = DateTime.Now;
                    repositorioPedido.Incluir(pedido);

                    double valorTotalPedido = 0;

                    var itemPedido = new ItemPedido();
                    foreach (var item in dadosPedido.ListaItens)
                    {
                        itemPedido.PedidoId = pedido.UUId;
                        itemPedido.ProdutoId = item.ProdutoId;
                        itemPedido.PercentualDesconto = item.PercentualDesconto;
                        itemPedido.Total = 0;

                        var produto = repositorioProduto.Find(item.ProdutoId);

                        var valorTotal = (produto.PrecoUnit * item.Qtd);

                        if (item.PercentualDesconto < 0)
                            item.PercentualDesconto = Math.Abs(item.PercentualDesconto);

                        valorTotalPedido += itemPedido.Total -= (itemPedido.Total * 100) / item.PercentualDesconto;

                        repositorioItemPedido.Incluir(itemPedido);

                    }

                    pedido.Numero = pedido.UUId;
                    pedido.Total = valorTotalPedido;
                }

                return "Pedido e Itens do Pedido inserido com sucesso";
            }
            catch (Exception Ex)
            {
                return "Erro: " + Ex.Message;
            }

        }

        public List<RetornoPedidosModel> BuscarPedidos(string numero, int? idPessoa)
        {
            var consultaPedidos = repositorioPedido.GetAll();
            if (!string.IsNullOrEmpty(numero))
            {
                int numeroPesquisa = 0;
                int.TryParse(numero, out numeroPesquisa);
                consultaPedidos = consultaPedidos.Where(x => x.Numero == numeroPesquisa);
            }
            if (idPessoa.HasValue && idPessoa.Value > 0)
                consultaPedidos = consultaPedidos.Where(x => x.PessoaId == idPessoa);

            var retorno = new List<RetornoPedidosModel>();

            if (consultaPedidos.Any())
                consultaPedidos.ToList().ForEach(x => retorno.Add(new RetornoPedidosModel() { UUId = x.UUId, Numero = x.Numero, Pessoa = x.Pessoa.Nome, Total = x.Total }));

            return retorno;
        }

        public List<DropModel> Clientes()
        {
            var retorno = new List<DropModel>();
            retorno.Add(new DropModel() { uuid = 0, model = "Selecionar" });
            var consultaPessoas = repositorioPessoa.GetAll();

            consultaPessoas.ToList().ForEach(x => retorno.Add(new DropModel() { uuid = x.UUId, model = x.Nome }));

            return retorno;
        }
    }
}
