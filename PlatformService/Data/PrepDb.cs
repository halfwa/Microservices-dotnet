using PlatformService.Data;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDp
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>()!);
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Sedding data...");        

                context.AddRange(
                    new Platform() {Name = "Dot NET", Publisher = "Microsoft", Coast = "Free"},
                    new Platform() {Name = "MS SQL Server Express", Publisher = "Microsoft", Coast = "Free"},
                    new Platform() {Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Coast = "Free"}                    
                );  

                context.SaveChanges();      
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}