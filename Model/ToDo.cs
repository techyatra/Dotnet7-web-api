using Sieve.Attributes;

namespace TechYatraAPI.Model
{
    public class ToDo
    {
        public int Id { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
