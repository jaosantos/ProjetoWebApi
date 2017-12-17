using System.Collections.Generic;

namespace WebApi.Entidade.Entidades
{
    public class Produto : EntityBase
    {
        public string Codigo { get; set; }

        public string Nome { get; set; }
        
        public double PrecoUnit { get; set; }

        public virtual ICollection<ItemPedido> ItensPedidos { get; set; }
    }
}
