using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControleChamado.Model;

namespace ControleChamado.View
{
    public partial class frmProduto : Form
    {
        public frmProduto()
        {
            InitializeComponent();
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            List<String> dadosProduto = new List<string>();

            dadosProduto.Add("0");
            dadosProduto.Add(txbProduto.Text);

            ProdutoController clienteController = new ProdutoController();
            clienteController.CadastraProduto(dadosProduto);

            MessageBox.Show(clienteController.mensagem);
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            ProdutoController produtoController = new ProdutoController();

            dgListaProduto.DataSource = produtoController.ListarProduto();
        }
    }
}
