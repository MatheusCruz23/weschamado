
namespace ControleChamado.Model
{
    public abstract class absProduto
    {
        //Atributos Proutos
        private int _idProduto;
        private string _produtoNome;

        //Encapsulamento Produto
        public string ProdutoNome
        {
            set { _produtoNome = value; }
            get { return _produtoNome; }
        }

        public int IdProduto
        {
            get { return _idProduto; }
        }
    }
}
