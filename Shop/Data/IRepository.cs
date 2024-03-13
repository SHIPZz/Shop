using Shop.Models;

namespace Shop.Data;

public interface IRepository<T>
{
   IQueryable<T> GetAll();
   Task Add(T entity);
   Task Remove(T entity);
   Task Update(T entity);
}