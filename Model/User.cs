using Sieve.Attributes;

namespace TechYatraAPI.Model
{
    public class User
    {
        public int Id { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]
        public string Name { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }

    }
}
