using System.ComponentModel.DataAnnotations.Schema;

namespace Practyca02_04_2023.Models
{
    public class Task
    {
        [ForeignKey("Id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public Task() {}
        public Task(string name, string description)
        {
            Name = name;
            Description = description;
            Status = false;
        }
        public Task(string name, string description, bool status)
        {
            Name = name;
            Description = description;
            Status = status;
        }
    }
}
