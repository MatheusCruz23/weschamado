using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleChamado.Model
{
    public class ProdutoValidacao :absProduto
    {
        public ProdutoValidacao(List<string> Dados) : base (Dados)
        {

        }

        public void ValidaProduto()
        {
            this.Mensagem = "";

            try
            {
                this.IdProduto = Convert.ToInt32(Dados[0]);

                if (Dados[1].Equals(""))
                {
                    this.Mensagem = "Preencha o campo com o nome do produto";
                }
                else
                {
                    this.Mensagem = "Produto salvo com sucesso";
                }

            }
            catch (Exception e)
            {
                this.Mensagem = "Erro ao salvar o produto";
            }
        }
    }
}
