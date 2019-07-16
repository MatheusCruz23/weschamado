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
            List<String> Dados = new List<string>();

            Dados.Add("0");
            Dados.Add(txbProduto.Text);

            ClienteController clienteController = new ClienteController(Dados);

            MessageBox.Show(clienteController.Mensagem);
        }
    }
}
