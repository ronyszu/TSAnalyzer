using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess
{
    public class EFDbContext:DbContext
    {

        public EFDbContext(DbContextOptions<EFDbContext> options):base(options)
        { }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}
