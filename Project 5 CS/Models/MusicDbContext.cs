namespace Project_5_CS.Models
{
    using Microsoft.EntityFrameworkCore;

    public class MusicDbContext : DbContext
    {
        public MusicDbContext(DbContextOptions<MusicDbContext> options)
            : base(options)
        {
        }

        public DbSet<Music> Music { get; set; }
    }
}