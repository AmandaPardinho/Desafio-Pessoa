using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.DirectoryServices;
using System.IO;
using System.Text;
using BibliotecaPessoa;

namespace FormsCadastroPessoa
{
    public partial class formCadastro : Form
    {
        public formCadastro()
        {
            InitializeComponent();
        }

        //Detecta se tem ou n�o algum texto
        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            if (nome == "")
            {
                MessageBox.Show("Insira um nome");
            }
        }

        //determina o que acontece quando o checkbox painel est� ticado
        private void cBoxPainel_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxPainel.Checked == true)
            {
                cBoxPopUp.Checked = false;
            }
        }

        //determina o que acontece quando o checkbox pop up est� ticado
        private void cBoxPopUp_CheckedChanged(object sender, EventArgs e)
        {
            if (cBoxPopUp.Checked == true)
            {
                cBoxPainel.Checked = false;
            }
        }

        //valida��o que impede que o usu�rio digite n�meros ou caracteres especiais
        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            int tecla = (int)e.KeyChar;

            if (!char.IsLetter(e.KeyChar) && tecla != 08)
            {
                e.Handled = true;
                MessageBox.Show("Insira apenas letras", "Aten��o!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //imprime nome, data de nascimento e altura, conforme o checkbox ticado e impede a impress�o dessas informa��es se o usu�rio n�o inserir o nome
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            string nome, altura, dataFormatada, resultado, anoNascimento;
            int anoAtual, ano, idade;
            DateTime data;

            data = dateCalendario.SelectionRange.Start.Date;
            // "d" => um dos par�metros permitidos pela conven��o de cadeias de caracteres de formato de data e hora padr�o
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
            var valorFinal = dropDownAltura.Value.ToString();


            //retoma a posi��o do calend�rio para a data de hoje
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

            //apaga as informa��es impressas se o checkBox do painel tiver sido clicado anteriormente
            lblResposta.ResetText();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblResposta.Text))
            {
                MessageBox.Show("Visualize os dados para conferi-los", "Aten��o!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

                      

            var texto = string.Empty;

            sfdSalvar.Filter = "All files | *.* | Arquivo Texto | *.txt | PDF | *.pdf | Documento word | *.docx ";
            sfdSalvar.FilterIndex = 0;

            sfdSalvar.FileName = "infos_pessoais_" + DateTime.Now.ToString("fff");
            texto = sfdSalvar.FileName;

            DialogResult resultado = sfdSalvar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                //using (FileStream fs = new FileStream(texto, FileMode.Create))
                using (StreamWriter escritor = new StreamWriter(texto))
                {
                    escritor.Write(lblResposta.Text);
                    escritor.Flush();
                    escritor.Close();
                }

                var mensagem = MessageBox.Show("Gostaria de abrir o arquivo para conferir o conte�do salvo?", "Aten��o!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (mensagem == DialogResult.Yes)
                {
                    using (FileStream fs = new FileStream(texto, FileMode.Open))
                    using (var leitor = new StreamReader(fs))
                    {
                        leitor.ReadToEnd();
                    }
                }
                else
                {
                    Close();
                }

            }
            else
            {
                MessageBox.Show("Opera��o Cancelada", "Aten��o!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}