using FilmDukkani.Models.Entities.Concrete;

using Microsoft.EntityFrameworkCore;

namespace FilmDukkani.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
