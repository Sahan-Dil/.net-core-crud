using Microsoft.EntityFrameworkCore;

namespace mvcCRUD.Models.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opts) : base(opts)
        {
             
        }

        public DbSet<Person> Person { get; set; }
    }
}
