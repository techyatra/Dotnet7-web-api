using Microsoft.EntityFrameworkCore;
using TechYatraAPI.Context;
using TechYatraAPI.Interface;

namespace TechYatraAPI.Service
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        private readonly ToDoContext _toDoContext;
        private DbSet<T> table = null;
        public GenericRepository(ToDoContext toDoContext)
        {
            _toDoContext = toDoContext;
            table = _toDoContext.Set<T>();
        }
        public T Add(T obj)
        {
            var result = table.Add(obj);
            _toDoContext.SaveChanges();
            return result.Entity;

        }

        public bool Delete(int id)
        {
            var result = table.Find(id);
            if (result == null)
            {
                throw new Exception("Delete the valid data");
            }
            try
            {
                _toDoContext.Remove(result);
                _toDoContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }


        }

        public List<T> GetAll()
        {
            var results = table.ToList();
            return results;
        }

        public T GetById(int id)
        {
            var result = table.Find(id);
            return result;
        }

        public T Update(T obj, int id)
        {
            var updatedData = _toDoContext.Update(obj);
            _toDoContext.SaveChanges();
            return updatedData.Entity;
        }

    }
}
