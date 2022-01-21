
using Microsoft.EntityFrameworkCore;
using SeriesAPI.Entities;

namespace SeriesAPI.Data
{
    public class APIContext : DbContext
    {
        public DbSet<Serie>? Series { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseSqlite("DataSource=app.db;cache=shared");
    }
}
