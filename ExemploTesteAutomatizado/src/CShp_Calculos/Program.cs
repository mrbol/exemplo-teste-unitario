using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliotecas;

namespace CShp_Calculos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Concat("Soma ", Calculo.Somar(1, 2)));
            Console.WriteLine(string.Concat("Subtrair ", Calculo.Subtrair(2, 1)));
            Console.WriteLine(string.Concat("Multiplicar ", Calculo.Multiplicar(2, 2)));
            Console.WriteLine(string.Concat("Dividir ", Calculo.Dividir(4, 2)));
            Console.Write("Pressione qualquer teclar para finalizar...");
            Console.ReadKey();
        }
    }
}
