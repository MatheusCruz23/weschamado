using System;
using System.Collections.Generic;


namespace ControleChamado.Model
{
    public class atrProduto
    {
        //Atributos Proutos
        private int _idProduto;
        private string _produtoNome;
        private string _mensagem;
        private List<string> _dados;
        
        //Encapsulamento Produto
        public string ProdutoNome
        {
            set { _produtoNome = value; }
            get { return _produtoNome; }
        }

        public int IdProduto
        {
            set { _idProduto = value; }
            get { return _idProduto; }
        }

        public string Mensagem
        {
            set { _mensagem = value; }
            get { return _mensagem; }
        }

        public List<string> Dados
        {
            set { _dados = value; }
            get { return _dados; }
        }
    }
}
