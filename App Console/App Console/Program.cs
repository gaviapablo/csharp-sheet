using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace App_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var leitor = new StreamReader("C:\\Users\\gavia\\OneDrive\\Documentos\\Murano\\Aprendendo\\C#\\primeiro-prog\\teste.csv"))
            using (var arquivo_csv = new CsvReader(leitor, CultureInfo.InvariantCulture))
            {
                var objetos = arquivo_csv.GetRecords<Ler>().ToList();
                float altura = 0;
                string nome = "";
                foreach (dynamic objeto in objetos)
                {
                    if (objeto.Altura>altura)
                    {
                        altura = objeto.Altura;
                        nome = objeto.Nome;
                    }
                }
                Console.WriteLine(nome + " tem a maior altura, com " + altura.ToString() + "centímetros.");

            }
            Console.ReadLine();

        }
        
        public class Ler
        {
            [Name("nome")]
            public string Nome { get; set; }

            [Name("idade")]
            public int Idade { get; set; }

            [Name("altura")]
            public float Altura { get; set; }

            [Name("peso")]
            public int Peso { get; set; }
        };

    }
}
