using Microsoft.AspNetCore.Mvc;

namespace hogwartshouses;

public interface IRepository<T>
{
    HashSet<T> GetAll();
    T GetById(int id);
}
