using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.DirectoryServices;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using ClosedXML.Excel;
using BibliotecaPessoa;
using ClosedXML;

namespace FormsCadastroPessoa
{
    public partial class formCadastro : Form
    {
        private decimal valorInicial;

        public formCadastro()
        {
            InitializeComponent();
            valorInicial = dropDownAltura.Value;
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
            dropDownAltura.Value = valorInicial;

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

        //salva arquivo contendo os dados inseridos pelo usuário
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            //verifica se o usuário inseriu valores nos campos
            if (string.IsNullOrEmpty(lblResposta.Text))
            {
                MessageBox.Show("Insira os dados e confira se estão corretos antes de salvar", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //formatos de arquivo em que é possível salvar a informação
            sfdSalvar.Filter = "All files (*.*) | *.* | Arquivo Texto (*.txt) | *.txt | PDF (*.pdf) | *.pdf | Documento word (*.docx) | *.docx | Arquivo XML (*.xml) | *.xml";
            sfdSalvar.FilterIndex = 0;

            sfdSalvar.FileName = "infos_pessoais_" + DateTime.Now.ToString("fff");

            DialogResult resultado = sfdSalvar.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                //caminho
                var dirSalvar = sfdSalvar.FileName;

                //cria o arquivo txt com as informações
                using (FileStream fs = new FileStream(dirSalvar, FileMode.Create))
                using (StreamWriter escritor = new StreamWriter(fs, Encoding.UTF8))
                {
                    escritor.Write(lblResposta.Text);
                    escritor.Flush();
                    escritor.Close();
                }

                MessageBox.Show("Arquivo salvo com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var mensagem = MessageBox.Show("Gostaria de abrir o arquivo para conferir o conteúdo salvo?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (mensagem == DialogResult.Yes)
                {
                    //abre o arquivo que foi gerado
                    Process.Start("notepad.exe", dirSalvar);
                }
                else
                {
                    Close();
                }

            }
            else
            {
                MessageBox.Show("Operação Cancelada", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            //define o formato do arquivo que o ShowDialog irá exibir
            ofdAbrir.Filter = "Arquivo Texto (*.txt) | *.txt";
            DialogResult resultado = ofdAbrir.ShowDialog();

            //caminho do arquivo
            var caminho = ofdAbrir.FileName;

            if (resultado == DialogResult.OK)
            {
                //abre e lê o arquivo
                using (FileStream fs = new FileStream(caminho, FileMode.Open))
                using (StreamReader leitor = new StreamReader(fs))
                {
                    Process.Start("notepad.exe", caminho);
                    leitor.ReadToEnd();
                }
            }

            //verifica se o caminho existe
            if (File.Exists(caminho))
            {
                //define um array a partir do conteúdo do arquivo
                string[] linhas = File.ReadAllLines(caminho);

                //acessa o arquivo e captura os valores para escrever no forms
                using (FileStream fs = new FileStream(caminho, FileMode.Open))
                {
                    //define o valor de txtNome
                    string nome = linhas[2];
                    txtNome.Text = nome.Substring(5);

                    //define o valor de dropDownAltura
                    string altura = linhas[3];
                    string padrao = "[0-9]{1,2},[0-9]{1,2}";
                    bool valorFinal = Regex.IsMatch(altura.Substring(7), padrao);
                    Match match = null;
                    if (valorFinal)
                    {
                        match = Regex.Match(altura.Substring(7), padrao);
                    }
                    dropDownAltura.Value = Decimal.Parse(match.Value);

                    //define a data do monthCalendar
                    string dataNascimento = linhas[4];
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    DateTime data = DateTime.ParseExact(dataNascimento.Substring(20), "dd/MM/yyyy", provider);
                    dateCalendario.SetDate(data);

                    //fecha o stream
                    fs.Close();
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //define o formato do arquivo que o ShowDialog irá exibir
            ofdAbrir.Filter = "Pasta de Trabalho do Excel (*.xlsx) | *.xlsx";
            DialogResult resultado = ofdAbrir.ShowDialog();

            //caminho do arquivo
            var caminho = ofdAbrir.FileName;

            if (resultado == DialogResult.OK)
            {
                //abre e lê o arquivo
                using (FileStream fs = new FileStream(caminho, FileMode.Open))
                using (StreamReader leitor = new StreamReader(fs))
                {
                    leitor.ReadToEnd();
                }
            }

            //cria o objeto do arquivo do tipo XLWorkbook
            var xlsx = new XLWorkbook(caminho);

            //cria a folha de trabalho
            var planilha = xlsx.Worksheets.First(sheets => sheets.Name == "Planilha1");

            //Obtém apenas as linhas usadas na planilha
            var planilhaPreenchida = planilha.RowsUsed();

            //Determina o número de linhas preenchidas da planilha
            var numeroLinhas = planilhaPreenchida.Count();
            
            var mensagem = MessageBox.Show($"Essa planilha tem um total de {numeroLinhas} linhas. Deseja ver os dados de uma dessas linhas?", "Atenção!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            switch (mensagem)
            {
                case DialogResult.Yes:
                    //exibe os dados de cada linha enquanto linhaAtual <= numeroLinhas
                    for (var linhaAtual = 2; linhaAtual <= numeroLinhas; linhaAtual++)
                    {
                        MessageBox.Show($"Mostrando os resultados da linha {linhaAtual}", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtNome.Text = planilha.Cell($"A{linhaAtual}").Value.ToString();
                        dropDownAltura.Value = Decimal.Parse(planilha.Cell($"B{linhaAtual}").Value.ToString());
                        DateTime.TryParse(planilha.Cell($"C{linhaAtual}").Value.ToString(), out DateTime data);
                        dateCalendario.SetDate(data);

                        var mensagem2 = MessageBox.Show("Deseja exibir a próxima linha?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(DialogResult.Yes == mensagem2)
                        {
                            mensagem2 = mensagem;
                        }
                        else
                        {
                            Close();
                        }
                    }
                    MessageBox.Show("Esses foram os valores de todas as linhas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case DialogResult.No:
                    Close();
                    break;
                case DialogResult.Cancel:
                    Close();
                    break;
                default:
                    Close();
                    break;
            }            
        }
    }
}