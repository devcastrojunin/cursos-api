using Microsoft.EntityFrameworkCore;
using cursos_api.Models;

namespace cursos_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}