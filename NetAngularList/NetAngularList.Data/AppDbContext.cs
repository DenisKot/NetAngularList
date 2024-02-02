using Microsoft.EntityFrameworkCore;
using NetAngularList.Domain;

namespace NetAngularList.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<ClientInfo> Clients { get; set; }
    }
}