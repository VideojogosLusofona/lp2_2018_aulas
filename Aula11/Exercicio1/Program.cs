using System;

namespace Exercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // Criar instâncias de MyVector usando três sintaxes diferentes
            //

            // Usando sintaxe normal do construtor
            MyVector myVec1 = new MyVector(-3.9f, 0.1f);

            // Usando sintaxe de incialização de objetos com propriedades
            MyVector myVec2 = new MyVector() { X = 1.6f, Y = -7.8f };

            // Usando sintaxe de inicialização de objetos com indexadores
            MyVector myVec3 = new MyVector() { ["a"] = 3f, ["b"] = 5.2f };

            //
            // Mostrar valores de X e Y das instâncias de MyVector de três
            // formas diferentes
            //
            Console.WriteLine($"myVec1 = ({myVec1[0]} ; {myVec1[1]})");
            Console.WriteLine($"myVec2 = ({myVec2["x"]} ; {myVec2["y"]})");
            Console.WriteLine($"myVec3 = ({myVec3.X} ; {myVec3.Y})");

            // Modificar valores de X e Y de myVec1 e mostrar alterações
            myVec1.X = -100f;
            myVec1["1"] = -200f;
            Console.WriteLine("Após modificação:");
            Console.WriteLine($"myVec1 = ({myVec1[0]} ; {myVec1[1]})");

        }
    }
}
