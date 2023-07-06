namespace TechYatraAPI.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        T Add(T obj);
        List<T> GetAll();
        T GetById(int id);
        T Update(T obj, int id);
        bool Delete(int id);
    }
}
