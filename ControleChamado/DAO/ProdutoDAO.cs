using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleChamado.DAO
{
    class ProdutoDAO : Model.intMetodo
    {
        public String mensagem;
        Conexao conexao = new Conexao();
        SqlCommand cmd = new SqlCommand();

        public void Cadastrar(List<String> Dados)
        {
            cmd.CommandText = @"insert into Produto (Produto) values (@produtoNome)";

            cmd.Parameters.AddWithValue("@produtoNome", Dados[1]);

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
                this.mensagem = "Erro ao tentar se conectar com o banco de dados";
            }
        }

        public void Excluir(List<String> Dados)
        {
            cmd.CommandText = @"delete from produto where IDProduto = @IdProduto";

            cmd.Parameters.AddWithValue("@IdProduto", Dados[1]);

            try
            {
                //conectar com o banco
                cmd.Connection = conexao.Conectar();
                //Executar comando
                cmd.ExecuteNonQuery();
                //Desconectar
                conexao.Desconectar();

                this.mensagem = "Excluido com sucesso";
            }
            catch (Exception e)
            {
                this.mensagem = "Erro ao tentar deletar o registro";
            }
        }

        public void Editar(List<String> Dados)
        {
            cmd.CommandText = @"update Produto set Produto = @nomeProduto where IDProduto = @IdProduto";

            cmd.Parameters.AddWithValue("@IdProduto", Dados[0]);
            cmd.Parameters.AddWithValue("@nomeProduto", Dados[1]);

            try
            {
                //Conectar no banco
                cmd.Connection = conexao.Conectar();
                //Executar comando
                cmd.ExecuteNonQuery();
                //Desconectar
                conexao.Desconectar();

                this.mensagem = "Editado com sucesso";
            }
            catch (Exception e)
            {
                this.mensagem = "Erro ao editar";
            }
        }

        public void Listar(List<String> Dados)
        {
            cmd.CommandText = @"select * from Produto";

            try
            {
                //conectar com o banco
                cmd.Connection = conexao.Conectar();
                //Executar comando
                cmd.ExecuteNonQuery();
                //Desconectar banco
                conexao.Desconectar();
            }
            catch (Exception e)
            {
                this.mensagem = "";
            }
        }
    }
}
