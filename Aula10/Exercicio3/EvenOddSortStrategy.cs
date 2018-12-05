using System.Collections.Generic;

namespace Exercicio3
{
    // Estrategia de comparação de inteiros que dá prioridade aos pares
    // relativamente aos ímpares
    public class EvenOddSortStrategy : IComparer<int>
    {

        // A interface IComparer<T> obriga a implementar este método
        public int Compare(int x, int y)
        {
            // Se x for par e y não for, x vem primeiro
            if ((x % 2 == 0) && (y % 2 != 0)) return -1;
            // Se x for impar e y for par, y vem primeiro
            else if ((x % 2 != 0) && (y % 2 == 0)) return 1;
            // Se x e y forem ambos pares ou impares, devolver a comparação
            // esperada entre os dois
            else return x.CompareTo(y);
        }
    }
}
