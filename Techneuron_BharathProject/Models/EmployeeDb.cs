using Microsoft.EntityFrameworkCore;

namespace Techneuron_BharathProject.Models
{
    public class EmployeeDb:DbContext
    {
        public EmployeeDb(DbContextOptions<EmployeeDb>options):base(options) { }
        
        public DbSet<Employee> Employees { get; set; }
    }
}
