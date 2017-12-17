using System.Data.Entity;
using System.Reflection;
using WebApi.Data.Migrations;
using WebApi.Entidade.Entidades;

namespace WebApi.Data.Contexto
{
    public class BancoContexto : DbContext
    {
        //public DbSet<Pessoa> Cliente { get; set; }
        public BancoContexto() : base("BancoContexto")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BancoContexto, Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>().ToTable("Pessoa");
            modelBuilder.Entity<Produto>().ToTable("Produto");


            modelBuilder.Entity<Pedido>()
                .HasOptional(x => x.Pessoa)
                .WithMany(x => x.Pedidos)
                .HasForeignKey(x => x.PessoaId);

            modelBuilder.Entity<ItemPedido>()
                .HasOptional(x => x.Produto)
                .WithMany(x => x.ItensPedidos)
                .HasForeignKey(x => x.ProdutoId);

            modelBuilder.Entity<ItemPedido>()
                .HasOptional(x => x.Pedido)
                .WithMany(x => x.ItensPedidos)
                .HasForeignKey(x => x.ProdutoId);

        }
    }
}
