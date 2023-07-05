using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FormsCadastroPessoa
{
    public class Person
    {
        private string pattern = "[0-9]{1,2}/[0-9]{1,2}/[0-9]{4}";
        private string _birthday;

        public string Name { get; set; }
        public string Birthday
        {
            get
            {
                var result = Regex.IsMatch(_birthday, pattern);
                Match match = null;
                if (result)
                {
                    match = Regex.Match(_birthday, pattern);
                }

                return match.Value;
            }

            set
            {
                if (value != null)
                {
                    _birthday = value;
                }
            }
        }
        public double Height { get; private set; }

        public Person(string name, string birthday, double height)
        {
            Name = name;
            Height = height;
            Birthday = birthday;
        }

        public Person()
        {
            
        }

        public override string ToString()
        {
            //return $"===== Personal Infos =====\n\nName: {Name}\nBirthday: {Birthday}\nHeight: {Height}m";
            return $"===== Personal Infos =====\n\nName: {Name}";
        }

        public void CalculateAge()
        {
            string data = Birthday;

            string yearBirth = data.Substring(data.Length - 4);
            int year = Int32.Parse(yearBirth);

            int yearNow = DateTime.Now.Year;
            int age = yearNow - year;
            Console.WriteLine($"Age: {age} years old");
        }
    }
}
