using System.ComponentModel.DataAnnotations;

namespace WebApi.Entidade
{
    public class EntityBase
    {
        [Key]
        public int UUId { get; set; }
    }
}
