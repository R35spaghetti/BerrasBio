using Microsoft.EntityFrameworkCore;

namespace BerrasBio.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(MovieContext context)
        {
            context.Database.EnsureCreated();


            if (context.Movies.Any())
            {
                return;
            }
            var movies = new Movie[]
            {
                new Movie{Name = "Glen i Göteborg", Minutes = 60, Price = 30},
                new Movie{Name = "Den där", Minutes=50, Price = 20}

            };
            context.Movies.AddRange(movies);
            context.SaveChanges();

            var tickets = new Ticket[]
            {
                new Ticket{MovieID =1, Amount =49 },
                new Ticket {MovieID =2, Amount =35}
                
            };
            context.Tickets.AddRange(tickets);
            context.SaveChanges();

        }

        
    }
}
