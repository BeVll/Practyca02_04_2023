
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;

namespace Practyca02_04_2023.Models
{

    public class TaskContext : DbContext
    {

        public DbSet<Task> Tasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=todo;user=root;password=");
        }

    }
}
