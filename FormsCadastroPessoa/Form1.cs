using System.ComponentModel.Design.Serialization;
using static FormsCadastroPessoa.Person;

namespace FormsCadastroPessoa
{
    public partial class formCadastro : Form
    {
        public formCadastro()
        {
            InitializeComponent();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            if(nome == null)
            {
                MessageBox.Show("Insira um nome");
            }
        }

        private void cBoxPainel_CheckedChanged(object sender, EventArgs e)
        {
            if(cBoxPainel.Checked == true)
            {
                cBoxPopUp.Checked = false;
            }
            else
            {
                cBoxPopUp.Checked = true;
            }
        }

        private void cBoxPopUp_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxPopUp.Checked == true)
            {
                cBoxPainel.Checked = false;
            }
            else
            {
                cBoxPainel.Checked = true;
            }            
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            int tecla = (int)e.KeyChar;

            if (!char.IsLetter(e.KeyChar) && tecla != 08)
            {
                e.Handled = true;
                MessageBox.Show("Insira apenas letras", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string nome, data, altura, resultado;
            nome = txtNome.Text;
            data = dateCalendario.Text;
            altura = dropDownAltura.Text;
            resultado = $"{nome}\n{data}\n{altura}";
            try
            {
                if (cBoxPainel.Checked)
                {
                    lblResposta.Visible = true;
                    lblResposta.Text = resultado;
                }
                else if (cBoxPopUp.Checked)
                {
                    MessageBox.Show(resultado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Preencha os demais campos", ex.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {        
            lblResposta.ResetText();
            txtNome.ResetText();
            dateCalendario.ResetText();
            dropDownAltura.ResetText();
            if (cBoxPainel.Checked || cBoxPopUp.Checked)
            {
                cBoxPainel.Checked = false;
                cBoxPopUp.Checked = false;

            }
        }
    }
}