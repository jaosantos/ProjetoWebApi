using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Business.Cadastro
{
    public interface ICadastro<T>
    {

        void Salvar(T model);
    }
}
