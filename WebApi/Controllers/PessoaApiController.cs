using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Http;
using WebApi.Business.Cadastro;
using WebApi.Entidade.Entidades;

namespace WebApi.Controllers
{
    
    public class PessoaApiController : ApiController
    {
        PessoaBusiness pessoaBusiness;
        public PessoaApiController()
        {
            this.pessoaBusiness = new PessoaBusiness();
        }

        [HttpPost]
        public string IncluirPessoa(string nome, string dataNascimento)
        {
            return pessoaBusiness.Salvar(nome, dataNascimento);
            
        }

        [HttpGet]
        public List<Business.PessoaModel> BuscarPessoas(string nome, string dataNascimento)
        {
            return pessoaBusiness.BuscarPessoas(nome, dataNascimento);
        }

        [HttpGet]
        public Pessoa BuscarPessoa(int idPessoa)
        {
            return pessoaBusiness.BuscarPessoa(idPessoa);
        }

        [HttpPost]
        public string Pessoa(int idPessoa, string nome, string dataNascimento)
        {
            return pessoaBusiness.Alterar(idPessoa, nome, dataNascimento);
        }

        [HttpPost]
        public string Pessoa(int id)
        {
                return pessoaBusiness.Excluir(id);
        }
    }
}
