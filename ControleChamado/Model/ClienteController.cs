using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleChamado.DAO;
using System.Data;

namespace ControleChamado.Model
{
    public class ClienteController
    {
        public String mensagem;
        public void CadastraProduto(List<String> dadosProduto)
        {
            this.mensagem = "";
            ProdutoValidacao produtoValidacao = new ProdutoValidacao();
            produtoValidacao.ValidarProduto(dadosProduto);
            if (produtoValidacao.mensagem.Equals(""))
            {
                atrProduto atributoProduto = new atrProduto();
                atributoProduto.ProdutoNome = dadosProduto[1];
                ProdutoDAO produtoDAO = new ProdutoDAO();
                produtoDAO.CadastrarProduto(atributoProduto);
                this.mensagem = produtoDAO.mensagem;
            }
            else
            {
                this.mensagem = produtoValidacao.mensagem;
            }
        }

        public DataTable ListarProduto()
        {
            try
            {
                ProdutoDAO produto = new ProdutoDAO();
                DataTable dt = new DataTable();

                dt = produto.ListarProduto();

                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
