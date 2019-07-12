using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleChamado.Model
{
    public interface intMetodo
    {
        void Cadastrar(List<String> Dados);
        void Excluir(List<String> Dados);
        void Editar(List<String> Dados);
        void Listar(List<String> Dados);
    }
}
