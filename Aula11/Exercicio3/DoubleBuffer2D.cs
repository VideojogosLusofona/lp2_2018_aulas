using System;

// Classe que implementa um double buffer bidimensional de tipo genérico
public class DoubleBuffer2D<T> : IBuffer2D<T>
{

    // Os dois buffers
    private T[,] nextBuffer, currentBuffer;

    // Indexador, serve para ler e escrever no double buffer de forma
    // transparente
    public T this[int x, int y]
    {
        // Leitura é feita do buffer current
        get => currentBuffer[x, y];
        // Escrita é feita no buffer next
        set => nextBuffer[x, y] = value;
    }

    // Propriedades que indicam o tamanho do buffer
    public int XDim => currentBuffer.GetLength(0);
    public int YDim => currentBuffer.GetLength(1);

    // Construtor, inicializa os buffers e limpa o buffer next
    public DoubleBuffer2D(int x, int y)
    {
        currentBuffer = new T[x, y];
        nextBuffer = new T[x, y];
        Clear();
    }

    // Método que limpa o buffer next
    public void Clear()
    {
        Array.Clear(nextBuffer, 0, XDim * YDim - 1);
    }

    // Troca os buffers, current passa a ser o antigo next e o next passa a ser
    // o antigo current
    public void Swap()
    {
        T[,] aux = currentBuffer;
        currentBuffer = nextBuffer;
        nextBuffer = aux;
    }

}
