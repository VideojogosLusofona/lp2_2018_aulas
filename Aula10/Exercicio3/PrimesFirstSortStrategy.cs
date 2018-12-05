using System.Collections.Generic;

namespace Exercicio3
{
    // Estrategia de comparação que dá prioridade aos números primos
    // relativamente aos números não primos
    public class PrimesFirstSortStrategy : IComparer<int>
    {
        // A interface IComparer<T> obriga a implementar este método
        public int Compare(int x, int y)
        {
            // Se x for primo e y não for, x vem primeiro
            if (IsPrime(x) && !IsPrime(y)) return -1;
            // Se x não for primo e y for, y vem primeiro
            else if (!IsPrime(x) && IsPrime(y)) return 1;
            // Se x e y forem ambos primos ou não primos, devolver a comparação
            // esperada entre os dois
            return x.CompareTo(y);
        }

        // Método auxiliar que retorna true se número for primo ou false caso
        // contrário
        private bool IsPrime(int i)
        {
            // Iniciar divisor em 2
            int n = 2;

            // Se numero for inferior a 2, então não é primo
            if (i < 2) return false;

            // Ciclo continua até ser possível determinar se número é primo ou
            // não
            while (true)
            {
                // Obter o resto da divisão inteira entre o número e o divisor
                // atual
                int r = i % n;
                // Se o resto for zero o número não é primo de certeza
                if (r == 0) return false;
                // Incrementar divisor
                n++;
                // Se divisor atual for igual ao número significa que nenhum
                // outro divisor deu resto zero, o que significa que o número é
                // primo
                if (n >= i) return true;
            }
        }
    }
}
