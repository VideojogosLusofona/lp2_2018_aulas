using System;

namespace Exercicio1
{
    public struct MyVector
    {
        // Propriedades
        public float X { get; set; }
        public float Y { get; set; }

        // Indexador com índices do tipo int que servem para aceder às
        // propriedades X e Y usando sintaxe tipo arrays
        public float this[int index]
        {
            get
            {
                if (index == 0) { return X; }
                else if (index == 1) { return Y; }
                else { throw new IndexOutOfRangeException(); }
            }
            set
            {
                if (index == 0) { X = value; }
                else if (index == 1) { Y = value; }
                else { throw new IndexOutOfRangeException(); }
            }
        }

        // Indexador com índices do tipo string que servem para aceder às
        // propriedades X e Y usando uma sintaxe semelhante à usada em
        // dicionários
        public float this[string index]
        {
            get
            {
                index = index.ToLower();
                if (index == "x" || index == "a" || index == "0") { return X; }
                else if (index == "y" || index == "b" || index == "1") { return Y; }
                else { throw new IndexOutOfRangeException(); }
            }
            set
            {
                index = index.ToLower();
                if (index == "x" || index == "a" || index == "0") { X = value; }
                else if (index == "y" || index == "b" || index == "1") { Y = value; }
                else { throw new IndexOutOfRangeException(); }
            }
        }

        // Construtor
        public MyVector(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
