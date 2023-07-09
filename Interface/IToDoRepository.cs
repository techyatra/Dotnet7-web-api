using TechYatraAPI.Model;

namespace TechYatraAPI.Interface
{
    public interface IToDoRepository : IGenericRepository<ToDo>
    {
        List<ToDo> GetCompletedTasks(int count);
    }
}
