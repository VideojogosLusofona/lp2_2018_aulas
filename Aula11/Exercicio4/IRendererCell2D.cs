namespace Exercicio4
{
    // Esta interface define a forma geral dos renderizadores para o
    // game of life
    public interface IRendererCell2D
    {
        // Método que faz o setup inicial antes da renderização começar
        void Setup(IBuffer2D<Cell> worldToRender);

        // Método que realiza a renderização do game of life
        void Render(IBuffer2D<Cell> worldToRender);
    }
}
