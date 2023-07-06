using Microsoft.EntityFrameworkCore;
using TechYatraAPI.Model;

namespace TechYatraAPI.Context
{
    public class ToDoContext: DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options): base(options)
        {

        }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
