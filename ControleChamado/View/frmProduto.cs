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

        //Método para salvar as informações do produto
        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            List<String> dadosProduto = new List<string>();

            dadosProduto.Add("0");
            dadosProduto.Add(txbProduto.Text);

            ProdutoController produtoController = new ProdutoController();
            produtoController.CadastraProduto(dadosProduto);

            txbProduto.Clear();

            MessageBox.Show(produtoController.mensagem);
        }

        //Método para carregar o DatagridView ao abrir a janela
        private void FrmProduto_Load(object sender, EventArgs e)
        {
            ProdutoController produtoController = new ProdutoController();

            dgListaProduto.DataSource = produtoController.ListarProduto();
        }

        //Método para selecionar as células do DataGridView
        private void DgListaProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = e.RowIndex;
            DataGridViewRow row = dgListaProduto.Rows[indexRow];
            lblIdProduto.Text = row.Cells[0].Value.ToString();
            txbProduto.Text = row.Cells[1].Value.ToString();
            lblIndexDataGrid.Text = Convert.ToString(indexRow);

        }

        //Método do botão editar
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            List<String> dadosProduto = new List<string>();

            dadosProduto.Add(lblIdProduto.Text);
            dadosProduto.Add(txbProduto.Text);

            ProdutoController produtoController = new ProdutoController();
            produtoController.EditarProduto(dadosProduto);

            txbProduto.Clear();

            dgListaProduto.DataSource = produtoController.ListarProduto();

            MessageBox.Show(produtoController.mensagem);
        }

        //Método do botão excluir
        private void BtnExcluir_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show(this, "Deseja realmente excluir essa informação?",
                "Excluir", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {

                List<String> dadosProduto = new List<string>();

                dadosProduto.Add(lblIdProduto.Text);
                dadosProduto.Add(txbProduto.Text);

                ProdutoController produtoController = new ProdutoController();
                produtoController.ExcluirProduto(dadosProduto);

                dgListaProduto.DataSource = produtoController.ListarProduto();

                MessageBox.Show(produtoController.mensagem);

            }                        
        }
    }
}
