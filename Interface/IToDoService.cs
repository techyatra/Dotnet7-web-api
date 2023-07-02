using TechYatraAPI.Model;

namespace TechYatraAPI.Interface
{
    public interface IToDoService
    {
        ToDo AddTask(ToDo todo);
        List<ToDo> GetAllTasks();
        ToDo ToDoGetTaskById(int id);
        ToDo UpdateTask(ToDo todo);
        bool DeleteTaskById(int id);
    }
}
