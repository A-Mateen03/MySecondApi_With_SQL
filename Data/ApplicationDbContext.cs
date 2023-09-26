using Microsoft.EntityFrameworkCore;
using MySecondApi_With_SQL.Model;

namespace MySecondApi_With_SQL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
