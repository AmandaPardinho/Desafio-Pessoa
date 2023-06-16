using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesafioPessoa
{
    public class Person
    {
        /*
         * Requisitos:
         * 1 - Nome, data de nascimento, altura
         * 2 - Métodos públicos necessários para sets e gets
         * 3 - Método para imprimir todos dados de uma pessoa
         * 4 - Método para calcular a idade da pessoa
         * 
         */
        private string pattern = "[0 - 9]{1,2}/{1}[0 - 9]{1,2}/{1}[0 - 9]{4}";
        private string _birthday;

        public string Name { get; private set; }
        public string Birthday 
        {
            get
            {
                Match result = Regex.Match(_birthday, pattern);

                if (result != null)
                {
                    return _birthday;
                }
                return "Insert the correct value to birthday";
            }
        }
        public double Height { get; private set; }

        public Person(string name, string birthday, double height)
        {
            Name = name;
            Height = height;
            _birthday = birthday;
        }        

        public override string ToString()
        {
            return $"Personal Infos\nName: {Name}\nBirthday: {Birthday}\nHeight: {Height}";
        }

        //public string CalculateAge()
        //{
            
             
        //}
    }
}
