namespace Version2
{
    public interface ICRUD <T> where T : IId
    {
        void Create(T item);
        T Read(int id);
        void Update(T item);
        void Delete(int id);
    }
}
