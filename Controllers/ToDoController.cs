using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using Sieve.Services;
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
        private readonly IGenericRepository<ToDo> _toDoService;
        private readonly SieveProcessor _sieveProcessor;
        public readonly ILogger<ToDoController> _logger;
        public ToDoController(IToDoService service,
  
            IGenericRepository<ToDo> toDoService, SieveProcessor sieveProcessor,
            ILogger<ToDoController> logger
            )
        {
            _service = service;
            _toDoService = toDoService;
            _sieveProcessor = sieveProcessor;
            _logger = logger;
        }
        // GET: api/<ToDoController>
        [HttpGet]
        public List<ToDo> Get([FromQuery] SieveModel model)
        {
            var tasks = _toDoService.GetAll().AsQueryable();
            tasks = _sieveProcessor.Apply(model, tasks);
            _logger.LogInformation("Getting all tasks");
              return tasks.ToList();
        }

        // GET api/<ToDoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //try
            //{
                var result = _toDoService.GetById(id);
                if (result == null)
                    throw new Exception("Getting errors while fetching customer details");

                return Ok(result);
            //}
            //catch(Exception ex)
            //{
               // _logger.LogError(ex.Message);
               // return BadRequest("Internal server error");
            //}
        }

        // POST api/<ToDoController>
        [HttpPost]
        public ToDo Post([FromBody] ToDo todo)
        {
            var task = _toDoService.Add(todo);
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
            var result = _toDoService.Update(value, id);
            return result;


        }

        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            bool result = _toDoService.Delete(id);
            return result;
        }
    }
}
