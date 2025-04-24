using Microsoft.EntityFrameworkCore;
using Task10.Models;

namespace Task10.Data
{
    public class AppDbContext:DbContext{

        //constructor it's invoked in program.cs file
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Book> Books { get; set; }
    }
}