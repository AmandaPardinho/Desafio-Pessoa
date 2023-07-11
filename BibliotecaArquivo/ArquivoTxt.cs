using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaArquivo
{
    public class ArquivoTxt
    {
        public static void CriaTxt(string componente1, string componente2)
        {
            var dirSalvar = componente1.FileName;
            
            using (FileStream fs = new FileStream(dirSalvar, FileMode.Create))
            using (StreamWriter escritor = new StreamWriter(fs, Encoding.UTF8))
            {
                escritor.Write(componente2);
                escritor.Flush();
                escritor.Close();
            }
        }
       
    }
}
