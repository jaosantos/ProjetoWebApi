using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Data.Repositorio;
using WebApi.Entidade.Entidades;

namespace WebApi.Business.Cadastro
{
    public class PessoaBusiness
    {
        IRepository<Pessoa> repositorioPessoa;
        public PessoaBusiness()
        {
            repositorioPessoa = new Repository<Pessoa>();
        }

        public List<PessoaModel> BuscarPessoas(string nome, string dataNascimento)
        {
            var retornoNascimento = validarData(dataNascimento);
            var consultaPessoa = repositorioPessoa.GetAll();
            if (!string.IsNullOrEmpty(nome))
                consultaPessoa = consultaPessoa.Where(x => x.Nome.ToUpper().Contains(nome.ToUpper()));

            if (retornoNascimento.HasValue)
                consultaPessoa = consultaPessoa.Where(x => x.DataNascimento.Date == retornoNascimento.Value.Date);

            var listaPessoas = new List<PessoaModel>();

            consultaPessoa.ToList().ForEach(x => listaPessoas.Add(new PessoaModel() {Id = x.UUId, Nome= x.Nome, DataNascimento = x.DataNascimento.ToShortDateString() }));

            return listaPessoas;
        }

        public string Salvar(string nome, string dataNascimento)
        {
            try
            {
                var mensagem = string.Empty;
                var retornoDataNascimento = validarData(dataNascimento);

                if (string.IsNullOrEmpty(nome))
                {
                    mensagem += "O nome é obrigátorio";
                }
                if (string.IsNullOrEmpty(dataNascimento))
                {
                    mensagem += "\r\n A data de nascimento é obrigátorio";
                }
                if (string.IsNullOrEmpty(mensagem) && retornoDataNascimento.HasValue)
                {
                    var pessoa = new Pessoa();
                    pessoa.DataNascimento = retornoDataNascimento.Value;
                    pessoa.Nome = nome;
                    repositorioPessoa.Incluir(pessoa);
                }
                return "";
            }
            catch (Exception Ex)
            {
                return "Erro: " + Ex.Message;
            }
            
        }

        public string Alterar(int uid, string nome, string dataNascimento)
        {
            try
            {
                var mensagem = string.Empty;
                var retornoDataNascimento = validarData(dataNascimento);

                if(string.IsNullOrEmpty(nome))
                {
                    mensagem += "O nome é obrigátorio";
                }
                if(string.IsNullOrEmpty(dataNascimento))
                {
                    mensagem += "\r\n A data de nascimento é obrigátorio";
                }
                if (string.IsNullOrEmpty(mensagem) && retornoDataNascimento.HasValue)
                {
                    var pessoa = repositorioPessoa.Find(uid);
                    if (pessoa != null)
                    {
                        pessoa.DataNascimento = retornoDataNascimento.Value;
                        pessoa.Nome = nome;
                        repositorioPessoa.Alterar(pessoa);
                    }
                }
                return "Alteração realizado com sucesso";
            }
            catch(Exception Ex)
            {
                return "Erro: " + Ex.Message;
            }
        }

        public Pessoa BuscarPessoa(int uid)
        {
            try
            {
                return repositorioPessoa.Find(uid);
                
            }
            catch (Exception ex)
            {
                return new Pessoa();
            }
        }

        public string Excluir(int uid)
        {
            try
            {
                var pessoa = repositorioPessoa.Find(uid);
                if (pessoa != null)
                    repositorioPessoa.Excluir(pessoa);
                return "Excluído com sucesso";
            }
            catch (Exception Ex)
            {
                return "Erro: " + Ex.Message;
            }
        }
        
        private DateTime? validarData(string DataNascimento)
        {
            DateTime dataNaci;
            DateTime.TryParse(DataNascimento, out dataNaci);
            if (dataNaci.Year > 1)
                return dataNaci;
            return null;
        }

    }
}
