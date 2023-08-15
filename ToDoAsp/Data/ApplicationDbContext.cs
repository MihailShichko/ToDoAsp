using Microsoft.EntityFrameworkCore;
using ToDoAsp.Models.Records;

namespace ToDoAsp.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Record> Records => Set<Record>(); 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
    }
}
