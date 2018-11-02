namespace Aula04
{
    public interface IComponent<T>
    {
        void Add(T child);
        void Remove(T child);
        T GetChild(int i);
    }
}
