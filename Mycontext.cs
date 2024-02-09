using Microsoft.EntityFrameworkCore;
using PracticeTest.Entities;

namespace PracticeTest.Database
{
    public class Mycontext:DbContext
    {
        private readonly IConfiguration configuration;
        public Mycontext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public DbSet<User>? Users { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
