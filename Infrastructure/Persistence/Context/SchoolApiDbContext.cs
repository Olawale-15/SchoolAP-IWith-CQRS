using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence.Context
{
    public class SchoolApiDbContext:DbContext
    {
        public SchoolApiDbContext(DbContextOptions<SchoolApiDbContext> options):base(options)
        {
            
        }

        public DbSet<Student> Students => Set<Student>();
    }
}
