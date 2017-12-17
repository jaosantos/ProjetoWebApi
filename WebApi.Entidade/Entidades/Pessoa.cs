using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Entidade.Entidades
{
    public class Pessoa : EntityBase
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
