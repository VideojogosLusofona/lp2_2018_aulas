using System;
using System.Threading;

namespace Exercicio3
{
    public class GameOfLife
    {
        // Variáveis de instância
        private DoubleBuffer2D<bool> simWorld;
        private Random random;
        private IRendererBool2D renderer;

        // Construtor
        public GameOfLife(
            int xdim, int ydim, double aliveProb, IRendererBool2D renderer)
        {
            // Inicializar gerador de números aleatórios
            random = new Random();

            // Criar double buffer onde vamos guardar o mundo
            simWorld = new DoubleBuffer2D<bool>(xdim, ydim);

            // Guardar renderer
            this.renderer = renderer;

            // Inicializar mundo
            for (int y = 0; y < ydim; y++)
            {
                for (int x = 0; x < xdim; x++)
                {
                    // Células estão vivas com probabilidade aliveProb
                    simWorld[x, y] = random.NextDouble() < aliveProb;
                }
            }

            // Garantir que mundo inicializado fica disponível para leitura
            simWorld.Swap();
        }

        // Método que implementa o game loop
        public void GameLoop(int msFramesPerSecond)
        {
            // Setup inicial do renderizador
            renderer.Setup(simWorld);

            // Iniciar game loop
            while (true)
            {
                // Obter tempo atual em ticks (10000 ticks = 1 milisegundo)
                long start = DateTime.Now.Ticks;

                // Update da simulação
                Update();

                // Fazer swap do buffer e envia-lo para o renderer
                simWorld.Swap();
                renderer.Render(simWorld);

                // Esperar até ser tempo da próxima iteração
                Thread.Sleep((int)
                    (start / 10000 + msFramesPerSecond
                    - DateTime.Now.Ticks / 10000));
            }
        }

        // Realiza um passo da simulação Game of Life
        private void Update()
        {
            // Percorrer todas as células
            for (int y = 0; y < simWorld.YDim; y++)
            {
                for (int x = 0; x < simWorld.XDim; x++)
                {
                    // Obter número de vizinhos vivos da célula atual
                    int neighs = GetAliveNeighbors(simWorld, x, y);

                    // Estado futuro da célula atual, assumimos que vai morrer
                    // Assim só temos de testar as regras nas quais a célula
                    // vive na próxima geração
                    bool nextState = false;

                    // Uma célula viva com 2 ou 3 vizinhos vivos viverá na
                    // próxima geração
                    if (simWorld[x, y] && neighs >= 2 && neighs <= 3)
                    {
                        nextState = true;
                    }
                    // Uma célula morta com 3 vizinhos viverá na próxima geração
                    else if (!simWorld[x, y] && neighs == 3)
                    {
                        nextState = true;
                    }

                    // Estabelecer estado futuro da célula atual no mundo de
                    // simulação
                    simWorld[x, y] = nextState;
                }
            }
        }

        // Método que devolve os vizinhos vivos da célula especificada
        private int GetAliveNeighbors(
            DoubleBuffer2D<bool> simWorld, int xCell, int yCell)
        {
            // Número de vizinhos vivos é inicialmente zero
            int aliveNeighbors = 0;

            // Percorrer todos os vizinhos da célula atual
            for (int y = yCell - 1; y <= yCell + 1; y++)
            {
                for (int x = xCell - 1; x <= xCell + 1; x++)
                {
                    // Se o vizinho atual for a célula atual, ignorar
                    if (x == xCell && y == yCell) continue;

                    // Obter coordenada x final do vizinho atual tendo em conta
                    // um mundo toroidal (que dá a volta)
                    int xFinal = x < 0 ? simWorld.XDim - 1
                        : (x >= simWorld.XDim ? 0 : x);

                    // Obter coordenada y final do vizinho atual tendo em conta
                    // um mundo toroidal (que dá a volta)
                    int yFinal = y < 0 ? simWorld.YDim - 1
                        : (y >= simWorld.YDim ? 0 : y);

                    // Se vizinho atual estiver vivo somar 1, caso contrário
                    // somar 0
                    aliveNeighbors += simWorld[xFinal, yFinal] ? 1 : 0;
                }
            }
            return aliveNeighbors;
        }
    }
}
