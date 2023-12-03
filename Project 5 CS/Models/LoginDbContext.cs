namespace Project_5_CS.Models
{
    using Microsoft.EntityFrameworkCore;

    public class LoginDbContext : DbContext
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options)
        {
        }

        public DbSet<LoginModel> Table { get; set; }
    }
}