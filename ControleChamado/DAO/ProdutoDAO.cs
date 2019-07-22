using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleChamado.DAO
{
    public class ProdutoDAO : intProdutoDAO
    {
        Conexao conexao = new Conexao();
        SqlDataReader dataReader;
        public String mensagem;        

        public void CadastrarProduto(Model.atrProduto atrProduto)
        {
            this.mensagem = "";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"insert into Produto (Produto) values (@produtoNome)";

            cmd.Parameters.AddWithValue("@produtoNome", atrProduto.ProdutoNome);

            try
            {
                //conectar com o banco
                cmd.Connection = conexao.Conectar();
                //Executar comando
                cmd.ExecuteNonQuery();
                //desconectar
                conexao.Desconectar();

                this.mensagem = "Cadastrado realizado com sucesso";
            }
            catch (Exception e)
            {
                this.mensagem = e.ToString();
            }
        }

        public void ExcluirProduto(Model.atrProduto atrProduto)
        {

        }

        public void EditarProduto(Model.atrProduto atrProduto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"UPDATE Produto SET ";

        }

        public DataTable ListarProduto()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"Select * from Produto";

            try
            {
                //conectar com o banco
                cmd.Connection = conexao.Conectar();
                SqlDataAdapter adptador = new SqlDataAdapter();
                adptador.SelectCommand = cmd;
                DataTable dt = new DataTable();

                adptador.Fill(dt);

                return dt;
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
