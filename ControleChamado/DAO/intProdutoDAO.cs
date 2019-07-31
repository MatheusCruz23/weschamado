using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ControleChamado.DAO
{
    //Interface para obrigar a utilização dos métodos abaixo
    interface intProdutoDAO
    {
        void CadastrarProduto(Model.atrProduto atrProduto);
        void ExcluirProduto(Model.atrProduto atrProduto);
        void EditarProduto(Model.atrProduto atrProduto);
        DataTable ListarProduto();
    }
}
