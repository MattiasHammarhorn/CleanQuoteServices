using CleanQuoteServices.Server.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanQuoteServices.Server.Data
{
    public class CleanQuoteServicesContext: DbContext
    {
        public CleanQuoteServicesContext(DbContextOptions<CleanQuoteServicesContext> options) 
            : base(options)
        { }

        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
