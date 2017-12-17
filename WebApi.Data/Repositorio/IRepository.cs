using System;
using System.Linq;
using WebApi.Entidade;

namespace WebApi.Data.Repositorio
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Get(Func<TEntity, bool> predicate);
        TEntity Find(int id);
        void Atualizar(TEntity obj);
        void SalvarTodos();
        void Adicionar(TEntity obj);
        void Excluir(TEntity obj);
        void Incluir(TEntity obj);
        void Alterar(TEntity obj);

    }
}