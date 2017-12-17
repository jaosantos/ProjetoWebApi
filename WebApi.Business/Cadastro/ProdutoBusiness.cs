using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Data.Repositorio;
using WebApi.Entidade.Entidades;

namespace WebApi.Business.Cadastro
{
    public class ProdutoBusiness
    {
        IRepository<Produto> repositorioProduto;
        public ProdutoBusiness()
        {
            repositorioProduto = new Repository<Produto>();
        } 

        public List<Produto> BuscarProdutos(string nome, string codigo)
        {
            var consultaProduto = repositorioProduto.GetAll();
            if (!string.IsNullOrEmpty(nome))
                consultaProduto = consultaProduto.Where(x => x.Nome.ToUpper().Contains(nome.ToUpper()));

            if (!string.IsNullOrEmpty(codigo))
                consultaProduto = consultaProduto.Where(x => x.Codigo.ToUpper().Equals(codigo.ToUpper()));

            return consultaProduto.ToList();
        }

        public string Salvar(string nome, double? precoUnitario, string codigo)
        {
            try
            {
                var mensagem = string.Empty;

                if (string.IsNullOrEmpty(nome))
                {
                    mensagem += "O nome é obrigátorio";
                }

                if (string.IsNullOrEmpty(codigo))
                {
                    mensagem += "O código é obrigátorio";
                }

                if (!precoUnitario.HasValue)
                {
                    mensagem += "\r\n O Preço unitário é obrigátorio";
                }
                if (string.IsNullOrEmpty(mensagem) )
                {
                    var produto = new Produto();

                    produto.Nome = nome;
                    produto.PrecoUnit = precoUnitario.Value;
                    produto.Codigo = codigo;
                    repositorioProduto.Incluir(produto);
                }
                return "Alteração realizada com sucesso";
            }
            catch (Exception Ex)
            {
                return "Erro: " + Ex.Message;
            }

        }

        public string Alterar(int uid, string nome, double? precoUnitario, string codigo)
        {
            try
            {
                var mensagem = string.Empty;

                if (string.IsNullOrEmpty(nome))
                {
                    mensagem += "O nome é obrigátorio";
                }
                if (string.IsNullOrEmpty(codigo))
                {
                    mensagem += "O código é obrigátorio";
                }
                if (!precoUnitario.HasValue)
                {
                    mensagem += "\r\n O Preço unitário é obrigátorio";
                }
                if (string.IsNullOrEmpty(mensagem))
                {
                    var produto = repositorioProduto.Find(uid);
                    if (produto != null)
                    {
                        produto.PrecoUnit = precoUnitario.Value;
                        produto.Nome = nome;
                        produto.Codigo = codigo;
                        repositorioProduto.Alterar(produto);
                    }
                }
                return "Alteração realizada com sucesso";
            }
            catch (Exception Ex)
            {
                return "Erro: " + Ex.Message;
            }
        }

        public Produto BuscarProduto(int uid)
        {
            try
            {
                return repositorioProduto.Find(uid);

            }
            catch (Exception ex)
            {
                return new Produto();
            }
        }

        public string Excluir(int uid)
        {
            try
            {
                var produto = repositorioProduto.Find(uid);
                if (produto != null)
                    repositorioProduto.Excluir(produto);
                return "Exclusão realizada com sucesso";
            }
            catch (Exception Ex)
            {
                return "Erro: " + Ex.Message;
            }
        }
    }
}
