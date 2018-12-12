namespace Exercicio4
{
    // Struct cell, representa uma célula no Game of Life
    public struct Cell
    {
        // Estado desta célula (true = viva, false = morta)
        public bool Alive { get; private set; }

        // Coordenadas desta célula no mundo de simulação
        private readonly int xCell, yCell;

        // Array de coordenadas dos vizinhos desta célula
        private readonly int[][] neighbors;

        // Referência ao mundo de simulação
        private readonly DoubleBuffer2D<Cell> simWorld;

        // Construtor
        public Cell(
            bool alive, int xCell, int yCell, DoubleBuffer2D<Cell> simWorld)
        {
            // Guardar dados passados no construtor
            Alive = alive;
            this.simWorld = simWorld;
            this.xCell = xCell;
            this.yCell = yCell;

            // Criar array de coordenadas dos vizinhos
            neighbors = new int[8][];

            // Indice das coordenadas do vizinho, começamos em zero
            int currentNeighbor = 0;

            // Percorrer todos os vizinhos da célula atual de modo a guardar
            // as respetivas coordenadas
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

                    // Obter coordenada x yinal do vizinho atual tendo em conta
                    // um mundo toroidal (que dá a volta)
                    int yFinal = y < 0 ? simWorld.YDim - 1
                        : (y >= simWorld.YDim ? 0 : y);

                    // Guardar coordenadas do vizinho atual
                    neighbors[currentNeighbor] = new int[] { xFinal, yFinal };

                    // Incrementar índice para guardarmos o próximo vizinho
                    currentNeighbor++;
                }
            }
        }

        // Atualizar esta célula na frame atual
        public void Update()
        {
            // Obter número de vizinhos vivos desta célula
            int neighs = GetAliveNeighbors();

            // Criar uma cópia desta célula; podemos fazer isto pois a célula
            // é uma struct, ou seja, um tipo de valor
            Cell nextCell = this;

            // Vamos assumir que o próximo estado da célula é morto, pois
            // assim só temos de testar as regras nas quais a célula
            // vive na próxima geração
            nextCell.Alive = false;

            // Uma célula viva com 2 ou 3 vizinhos vivos viverá na
            // próxima geração
            if (Alive && neighs >= 2 && neighs <= 3)
            {
                nextCell.Alive = true;
            }
            // Uma célula morta com 3 vizinhos viverá na próxima geração
            else if (!Alive && neighs == 3)
            {
                nextCell.Alive = true;
            }

            // Guardar célula futura no mundo de simulação
            simWorld[xCell, yCell] = nextCell;
        }

        // Obter número de vizinhos vivos na célula atual
        private int GetAliveNeighbors()
        {
            // Uma vez que guardamos as coordenadas dos vizinhos no construtor
            // basta agora percorrer o array que contém essas coordenadas
            int aliveNeighbors = 0;
            foreach (int[] neigh in neighbors)
            {
                // Se o vizinho atual estiver vivo, incrementar número de
                // vizinhos vivos
                aliveNeighbors += simWorld[neigh[0], neigh[1]].Alive ? 1 : 0;
            }
            return aliveNeighbors;
        }
    }
}
