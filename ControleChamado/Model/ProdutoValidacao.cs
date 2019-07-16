using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleChamado.Model
{
    public class ProdutoValidacao
    {
        public String mensagem;
        public int id;

        public void ValidarProduto(List<String> dadosProduto)
        {
            this.mensagem = "";
            if (dadosProduto[1].Equals(""))
            {
                this.mensagem = "Preencha corretamente o campo\n";
            }
            else if (dadosProduto[1].Length > 45)
            {
                this.mensagem += "O nome do produto muito extenso";
            }

            try
            {
                this.id = Convert.ToInt32(dadosProduto[0]);
            }
            catch (Exception e)
            {
                this.mensagem += "ID inválido";
            }
        }
    }
}
