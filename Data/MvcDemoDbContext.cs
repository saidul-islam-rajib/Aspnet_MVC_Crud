using Aspnet_MVC_Crud.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Aspnet_MVC_Crud.Data
{
    public class MvcDemoDbContext : DbContext
    {
        public MvcDemoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; } // this will be the table name
    }
}
