using Microsoft.AspNetCore.Mvc;
using TechYatraAPI.Interface;
using TechYatraAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechYatraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _service;
        public ToDoController(IToDoService service)
        {
            _service = service;
        }
        // GET: api/<ToDoController>
        [HttpGet]
        public List<ToDo> Get()
        {
            var tasks = _service.GetAllTasks();
            return tasks;
        }

        // GET api/<ToDoController>/5
        [HttpGet("{id}")]
        public ToDo Get(int id)
        {
            var result = _service.ToDoGetTaskById(id);
            return result;
        }

        // POST api/<ToDoController>
        [HttpPost]
        public ToDo Post([FromBody] ToDo todo)
        {
            var task = _service.AddTask(todo);
            return task;
        }

        // PUT api/<ToDoController>/5
        [HttpPut("{id}")]
        public ToDo Put(int id, [FromBody] ToDo value)
        {
            if (id != value.Id)
            {
                throw new Exception("Please enter the valid details");
            }
            var result = _service.UpdateTask(value);
            return result;


        }

        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            bool result = _service.DeleteTaskById(id);
            return result;
        }
    }
}
