using System.ComponentModel.Design.Serialization;
using BibliotecaPessoa;

namespace FormsCadastroPessoa
{
    public partial class formCadastro : Form
    {
        public formCadastro()
        {
            InitializeComponent();
        }

        //Detecta se tem ou não algum texto
        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            if (nome == "")
            {
                MessageBox.Show("Insira um nome");
            }
        }

        //determina o que acontece quando o checkbox painel está ticado
        private void cBoxPainel_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxPainel.Checked == true)
            {
                cBoxPopUp.Checked = false;
            }
        }

        //determina o que acontece quando o checkbox pop up está ticado
        private void cBoxPopUp_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxPopUp.Checked == true)
            {
                cBoxPainel.Checked = false;
            }
        }

        //validação que impede que o usuário digite números ou caracteres especiais
        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            int tecla = (int)e.KeyChar;

            if (!char.IsLetter(e.KeyChar) && tecla != 08)
            {
                e.Handled = true;
                MessageBox.Show("Insira apenas letras", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //imprime nome, data de nascimento e altura, conforme o checkbox ticado e impede a impressão dessas informações se o usuário não inserir o nome
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string nome, altura, dataFormatada, resultado, anoNascimento;
            int anoAtual, ano, idade;
            DateTime data;

            data = dateCalendario.SelectionRange.Start.Date;
            // "d" => um dos parâmetros permitidos pela convenção de cadeias de caracteres de formato de data e hora padrão
            dataFormatada = data.ToString("d");

            nome = txtNome.Text;
            altura = dropDownAltura.Text;

            Pessoa pessoa = new Pessoa();
            pessoa.Nome = nome;
            pessoa.DataNascimento = dataFormatada;
            pessoa.Altura = Double.Parse(altura);

            try
            {
                if (cBoxPainel.Checked)
                {
                    if (nome == "")
                    {
                        txtNome_TextChanged(sender, e);
                    }
                    else
                    {
                        lblResposta.Visible = true;
                        lblResposta.Text = pessoa.ToString();
                    }
                }
                else if (cBoxPopUp.Checked)
                {
                    MessageBox.Show(pessoa.ToString());
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Preencha os demais campos", ex.Message);
            }
        }

        //limpa os dados da tela
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //retoma o valor inicial do numericUpDown
            var valorInicial = "0,00";
            var valorFinal = dropDownAltura.Value.ToString(valorInicial);

            //retoma a posição do calendário para a data de hoje
            DateTime diaAtual = DateTime.Today;
            dateCalendario.SetDate(diaAtual);

            //deixa o checkBox do painel e do pop up sem ticar
            if (cBoxPainel.Checked || cBoxPopUp.Checked)
            {
                cBoxPainel.Checked = false;
                cBoxPopUp.Checked = false;
            }

            //apaga o nome
            txtNome.ResetText();

            //apaga as informações impressas se o checkBox do painel tiver sido clicado anteriormente
            lblResposta.ResetText();
        }
    }
}