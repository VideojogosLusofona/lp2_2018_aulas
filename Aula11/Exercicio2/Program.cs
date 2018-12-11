using System;

namespace Exercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criar um double buffer de chars e inicializa-lo com sintaxe de
            // inicialização de objetos com indexadores
            DoubleBuffer2D<char> myBuffer = new DoubleBuffer2D<char>(5, 5)
            {
                [0,0] = 'O', [1,0] = 'l', [2,0] = 'á', [3,0] = ' ', [4,0] = ' ',
                [0,1] = 'M', [1,1] = 'u', [2,1] = 'n', [3,1] = 'd', [4,1] = 'o',
                [0,2] = '-', [1,2] = '|', [2,2] = '-', [3,2] = '|', [4,2] = '-',
                [0,3] = '|', [1,3] = '-', [2,3] = '|', [3,3] = '-', [4,3] = '|',
                [0,4] = '-', [1,4] = '|', [2,4] = '-', [3,4] = '|', [4,4] = '-'
            };

            // Realizar swap, de modo a podermos ler conteúdos escritos no
            // double buffer
            myBuffer.Swap();

            // Ler e mostrar conteúdos escritos no double buffer
            for (int y = 0; y < myBuffer.YDim; y++)
            {
                for (int x = 0; x < myBuffer.XDim; x++)
                {
                    Console.Write(myBuffer[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}
