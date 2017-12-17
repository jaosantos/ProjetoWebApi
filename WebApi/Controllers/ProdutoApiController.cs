using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Business.Cadastro;

namespace WebApi.Controllers
{
    public class ProdutoApiController : ApiController
    {
        ProdutoBusiness produtoBusiness;
        public ProdutoApiController()
        {
            this.produtoBusiness = new ProdutoBusiness();
        }

        [HttpPost]
        public string Produto(string nome, string codigo, double precoUnitario)
        {
            return produtoBusiness.Salvar(nome, precoUnitario,codigo);

        }

        [HttpGet]
        public List<Entidade.Entidades.Produto> BuscarProdutos(string nome, string codigo)
        {
            return produtoBusiness.BuscarProdutos(nome, codigo);
        }

        [HttpGet]
        public Entidade.Entidades.Produto BuscarProduto(int idProduto)
        {
            return produtoBusiness.BuscarProduto(idProduto);
        }

        [HttpPost]
        public string Produto(int idProduto, string nome,string codigo, double precoUnitario)
        {
            return produtoBusiness.Alterar(idProduto, nome, precoUnitario, codigo);
        }

        [HttpPost]
        public string Produto(int Id)
        {
            return produtoBusiness.Excluir(Id);
        }
    }
}
