using Microsoft.EntityFrameworkCore;
using PersonManagement.Data.Contracts.Entities;

namespace PersonManagement.Data.Contexts
{
    public class PersonManagementDbContext : DbContext
    {
        public PersonManagementDbContext(DbContextOptions<PersonManagementDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Color> Colors { get; set; }
    }
}