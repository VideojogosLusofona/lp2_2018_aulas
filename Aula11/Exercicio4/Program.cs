namespace Exercicio4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciar um renderizador de consola para o nosso Game of Life
            IRendererCell2D renderer = new ConsoleRendererCell2D('#', '.');

            // Criar uma instância de game of life com dimensões 80x40, 20% de
            // probabilidade inicial de células vivas e com um renderizador de
            // consola
            GameOfLife gol = new GameOfLife(80, 40, 0.2, renderer);

            // Iniciar simulação, definir que cada frame deve durar
            // 100 milisegundos
            gol.GameLoop(100);
        }
    }
}
