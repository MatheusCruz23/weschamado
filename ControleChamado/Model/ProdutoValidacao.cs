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

            //Verifica se a informação que está vindo é para cadastrar/editar/excluir
            //Caso seja de cadastro o ID sempre será 0
            if (dadosProduto[0] == "0")
            {

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
            else
            {
                if (dadosProduto[1].Equals(""))
                {
                    this.mensagem = "Selecione um campo\n";
                }
                else if (dadosProduto[1].Length > 45)
                {
                    this.mensagem += "O nome do produto muito extenso";
                }

                try
                {
                    this.id = Convert.ToInt32(dadosProduto[0]);
                }
                catch (Exception)
                {
                    this.mensagem += "ID inválido";
                }
            }
        }
    }
}
