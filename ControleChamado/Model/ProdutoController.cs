using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleChamado.DAO;
using System.Data;

namespace ControleChamado.Model
{
    public class ProdutoController
    {
        public String mensagem;

        //Método para gerenciar o cadastro de produto
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

        //Método para gerenciar a listagem de produto
        public DataTable ListarProduto()
        {
            try
            {
                ProdutoDAO produtoDAO = new ProdutoDAO();
                DataTable dt = new DataTable();

                dt = produtoDAO.ListarProduto();

                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Método para editar o produto
        public void EditarProduto(List<String> dadosProduto)
        {
            this.mensagem = "";
            ProdutoValidacao produtoValidacao = new ProdutoValidacao();
            produtoValidacao.ValidarProduto(dadosProduto);
            if (produtoValidacao.mensagem.Equals(""))
            {
                atrProduto atributoProduto = new atrProduto();
                atributoProduto.Dados = dadosProduto;
                ProdutoDAO produtoDAO = new ProdutoDAO();
                produtoDAO.EditarProduto(atributoProduto);
                this.mensagem = produtoDAO.mensagem;
            }
            else
            {
                this.mensagem = produtoValidacao.mensagem;
            }
        }

        //Método para gerenciar a exclusão do produto
        public void ExcluirProduto(List<String> dadosProduto)
        {
            this.mensagem = "";
            ProdutoValidacao produtoValidacao = new ProdutoValidacao();
            produtoValidacao.ValidarProduto(dadosProduto);
            if (produtoValidacao.mensagem.Equals(""))
            {
                atrProduto atributoProduto = new atrProduto();
                atributoProduto.Dados = dadosProduto;
                ProdutoDAO produtoDAO = new ProdutoDAO();
                produtoDAO.ExcluirProduto(atributoProduto);
                this.mensagem = produtoDAO.mensagem;
            }
            else
            {
                this.mensagem = produtoValidacao.mensagem;
            }
        }
    }
}
