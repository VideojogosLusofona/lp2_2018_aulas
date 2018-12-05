using System;
namespace Exercicio2
{
    public abstract class Duck
    {
        // Variáveis de instância que contém os comportamentos do pato
        private Action flyBehaviour;
        private Action quackBehaviour;

        // Propriedades públicas que controlam o acesso externo aos
        // comportamentos do pato
        public Action FlyBehaviour
        {
            get => flyBehaviour;
            set { if (value != null) flyBehaviour = value; }
        }
        public Action QuackBehaviour
        {
            get => quackBehaviour;
            set { if (value != null) quackBehaviour = value; }
        }

        // Mostrar o pato, sub-classes é que sabem fazer o render do pato, por
        // isso o método é abstrato
        public abstract void Display();

        // Fazer quack, depende da estratégia definida para quack
        public void PerformQuack()
        {
            quackBehaviour.Invoke();
        }

        // Fazer fly, depende da estratégia definida para voo
        public void PerformFly()
        {
            flyBehaviour.Invoke();
        }
    }
}
