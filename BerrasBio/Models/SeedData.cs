using Microsoft.EntityFrameworkCore;

namespace BerrasBio.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            //MovieContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<MovieContext>();

            //if (context.Database.GetPendingMigrations().Any()
            //{
            //    context.Migrate();
            //}
        }
    }
}
