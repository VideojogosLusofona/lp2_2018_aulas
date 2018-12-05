namespace Exercicio1
{
    public abstract class Duck
    {
        // Variáveis de instância que contém os comportamentos do pato
        private IFlyBehaviour flyBehaviour;
        private IQuackBehaviour quackBehaviour;

        // Propriedades públicas que controlam o acesso externo aos
        // comportamentos do pato
        public IFlyBehaviour FlyBehaviour
        {
            get => flyBehaviour;
            set { if (value != null) flyBehaviour = value; }
        }
        public IQuackBehaviour QuackBehaviour
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
            quackBehaviour.Quack();
        }

        // Fazer fly, depende da estratégia definida para voo
        public void PerformFly()
        {
            flyBehaviour.Fly();
        }
    }
}
