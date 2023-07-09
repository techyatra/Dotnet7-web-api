using Microsoft.EntityFrameworkCore;
using TechYatraAPI.Context;
using TechYatraAPI.Interface;
using TechYatraAPI.Model;

namespace TechYatraAPI.Service
{
    public class ToDoRepository : GenericRepository<ToDo>, IToDoRepository
    {
        public ToDoRepository(ToDoContext context) : base(context)
        {
        }
        public List<ToDo> GetCompletedTasks(int count)
        {
            return table.Where(t => t.Status == "Completed").ToList();
        }
    }
}
