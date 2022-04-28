
namespace CreditCards.Infrastructure
{
    using CreditCards.Core.Model;

    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) :
            base(dbContextOptions)
        {
        }

        public DbSet<CreditCardApplication> CreditCardApplications { get; set; }
    }
}