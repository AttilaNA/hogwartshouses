namespace hogwartshouses;

public interface IRepository<T>
{
    HashSet<T> GetAll();
}
