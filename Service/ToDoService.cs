using Microsoft.EntityFrameworkCore;
using TechYatraAPI.Context;
using TechYatraAPI.Interface;
using TechYatraAPI.Model;

namespace TechYatraAPI.Service
{
    public class ToDoService : IToDoService
        
    {
        private readonly ToDoContext _toDoContext;
        public ToDoService(ToDoContext toDoContext)
        {
             _toDoContext = toDoContext;
        }
        public ToDo AddTask(ToDo todo)
        {
            var result = _toDoContext.ToDos.Add(todo);
            _toDoContext.SaveChanges();
            return result.Entity;

        }

        public bool DeleteTaskById(int id)
        {
            var result = _toDoContext.ToDos.SingleOrDefault(t => t.Id == id);
            if (result == null)
            {
                throw new Exception("Update the valid data");
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

        public List<ToDo> GetAllTasks()
        {
            var tasks = _toDoContext.ToDos.ToList();
            return tasks;
        }

        public ToDo ToDoGetTaskById(int id)
        {
            var todo = _toDoContext.ToDos.SingleOrDefault(t => t.Id == id);
            return todo;
        }

        public ToDo UpdateTask(ToDo todo)
        {
            var result = _toDoContext.ToDos.AsNoTracking().SingleOrDefault(t => t.Id == todo.Id);
            if (result == null)
            {
                throw new Exception("Update the valid data");
            }
           var updatedData =  _toDoContext.Update(todo);
            _toDoContext.SaveChanges();
            return updatedData.Entity;
        }
    }
}
