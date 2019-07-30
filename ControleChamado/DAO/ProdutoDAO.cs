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
        //SqlDataReader dataReader;
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
            this.mensagem = "";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"DELETE FROM Produto WHERE IDProduto = @id";

            cmd.Parameters.AddWithValue("@id", atrProduto.Dados[0]);

            try
            {
                //conectar com o banco
                cmd.Connection = conexao.Conectar();
                //Executar comando
                cmd.ExecuteNonQuery();
                //desconectar
                conexao.Desconectar();

                this.mensagem = "Excluido com sucesso!";
            }
            catch (Exception e)
            {
                this.mensagem = e.ToString();
            }
        }

        public void EditarProduto(Model.atrProduto atrProduto)
        {
            this.mensagem = "";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = @"UPDATE Produto SET Produto = @nomeProduto where IDProduto = @id";

            cmd.Parameters.AddWithValue("@id", atrProduto.Dados[0]);
            cmd.Parameters.AddWithValue("@nomeProduto", atrProduto.Dados[1]);

            try
            {
                //conectar com o banco
                cmd.Connection = conexao.Conectar();
                //Executar comando
                cmd.ExecuteNonQuery();
                //desconectar
                conexao.Desconectar();

                this.mensagem = "Editado com sucesso!";
            }
            catch (Exception e)
            {
                this.mensagem = e.ToString();
            }


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
