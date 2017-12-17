using System;
using System.Collections.Generic;

namespace WebApi.Entidade.Entidades
{
    public class Pedido : EntityBase
    {
        public int? PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        public int Numero { get; set; }
        
        public DateTime DataEmissao { get; set; }

        public double Total { get; set; }

        public virtual ICollection<ItemPedido> ItensPedidos { get; set; }
    }
}
