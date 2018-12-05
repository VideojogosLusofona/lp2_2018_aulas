using System;
using System.Collections.Generic;

namespace Exercicio3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicializar gerador de números aleatórios
            Random rnd = new Random();

            // Criar uma lista de 20 inteiros aleatórios entre 0 e 999
            List<int> listOfInts = new List<int>(20);
            for (int i = 0; i < 20; i++)
            {
                listOfInts.Add(rnd.Next(0, 1000));
            }

            // Ordenar lista pela ordenação natural
            Console.WriteLine("\n\nOrdenação natural:");
            listOfInts.Sort();
            PrintSequenceOfInts(listOfInts);

            // Ordenar lista pela ordenação "pares primeiro"
            Console.WriteLine("\n\nOrdenação pares primeiro:");
            listOfInts.Sort(new EvenOddSortStrategy());
            PrintSequenceOfInts(listOfInts);

            // Ordenar lista pela ordenação "primos primeiro"
            Console.WriteLine("\n\nOrdenação primos primeiro:");
            listOfInts.Sort(new PrimesFirstSortStrategy());
            PrintSequenceOfInts(listOfInts);

            Console.WriteLine("\n");

        }

        // Método auxiliar que imprime uma sequência de inteiros
        static void PrintSequenceOfInts(IEnumerable<int> intSequence)
        {
            foreach (int i in intSequence)
            {
                Console.Write($"{i:d3} ");
            }
        }
    }
}
