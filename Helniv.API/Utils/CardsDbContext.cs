using Helniv.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Helniv.API.Utils
{
    public class CardsDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;


        public CardsDbContext(DbContextOptions<CardsDbContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
    
    }

}
