using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BibliotecaPessoa
{
    public class Pessoa
    {
        private string padrao = "[0-9]{1,2}/[0-9]{1,2}/[0-9]{4}";
        private string _dataNascimento;

        public string Nome { get; set; }
        public string DataNascimento
        {
            get
            {
                var resultado = Regex.IsMatch(_dataNascimento, padrao);
                Match match = null;
                if (resultado)
                {
                    match = Regex.Match(_dataNascimento, padrao);
                }

                return match.Value;
            }

            set
            {
                if (value != null)
                {
                    _dataNascimento = value;
                }
            }
        }
        public double Altura { get; set; }

        public Pessoa()
        {

        }

        public Pessoa(string nome, string dataNascimento, double altura)
        {
            Nome = nome;
            Altura = altura;
            DataNascimento = dataNascimento;
        }


        public override string ToString()
        {
            return $"===== Personal Infos =====\n\nNome: {Nome}\nAltura{Altura}m\nData de Nascimento: {DataNascimento}\nIdade: {CalculaIdade()} anos";
        }

        public int CalculaIdade()
        {
            string data = DataNascimento;

            string anoNascimento = data.Substring(data.Length - 4);
            int ano = Int32.Parse(anoNascimento);

            int anoAtual = DateTime.Now.Year;
            int idade = anoAtual - ano;
            return idade;
        }
    }
}
