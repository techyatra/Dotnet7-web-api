using TechYatraAPI.Context;
using TechYatraAPI.Interface;
using TechYatraAPI.Model;

namespace TechYatraAPI.Service
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ToDoContext toDoContext) : base(toDoContext)
        {
        }
    }
}
