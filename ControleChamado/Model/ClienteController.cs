using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleChamado.DAO;

namespace ControleChamado.Model
{
    class ClienteController : absProduto
    {
        public ClienteController(List<String> Dados) : base(Dados)
        {

        }

        public void Executar()
        {
            this.Mensagem = "";


        }
    }
}
