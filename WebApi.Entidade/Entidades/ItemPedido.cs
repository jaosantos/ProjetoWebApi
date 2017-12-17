namespace WebApi.Entidade.Entidades
{
    public class ItemPedido : EntityBase
    {
        public int? ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public double PercentualDesconto { get; set; }

        public double Total { get; set; }

        public int? PedidoId { get; set; }

        public Pedido Pedido { get; set; }
    }
}
