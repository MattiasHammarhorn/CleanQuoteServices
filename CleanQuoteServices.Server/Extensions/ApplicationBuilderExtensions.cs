using CleanQuoteServices.Server.Data;
using CleanQuoteServices.Server.Data.Entities;

namespace CleanQuoteServices.Server.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<CleanQuoteServicesContext>();

                try
                {
                    var locations = new List<Location>()
                    {
                        new Location
                        {
                            LocationId = 1,
                            LocationName = "Stockholm",
                            PricePerSqm = 65,
                            HasBalconyCleaning = true,
                            HasWindowCleaning = true,
                            HasWasteCollection = false
                        },
                        new Location
                        {
                            LocationId = 2,
                            LocationName = "Uppsala",
                            PricePerSqm = 55,
                            HasBalconyCleaning = true,
                            HasWindowCleaning = true,
                            HasWasteCollection = true
                        }
                    };

                    context.AddRange(locations);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }
    }
}
