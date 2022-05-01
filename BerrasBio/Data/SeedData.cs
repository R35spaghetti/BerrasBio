using Microsoft.EntityFrameworkCore;
using BerrasBio.Models;
using BerrasBio.Data;

namespace BerrasBio.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IServiceProvider serviceProvider)
        {
            using (var context = new BerrasBioContext(serviceProvider.GetRequiredService<DbContextOptions<BerrasBioContext>>()))
            {
                if (context.Movie.Any())
                {
                    return;
                }
                var movies = new Movie[]
                {
                    new Movie{Name = "Glen i Göteborg", Minutes = 60, Price = 30, Date= new DateTime(2022,04,30,11,30,45) },
                    new Movie{Name = "Den där", Minutes=50, Price = 20, Date= new DateTime(2022,04,30,10,30,45), },
                          new Movie{Name = "Populär film", Minutes=120, Price = 60, Date= new DateTime(2022,04,30,12,30,45), }
                };
                context.Movie.AddRange(movies);
                context.SaveChanges();

               

                var movieTheater = new MovieTheater[]
                {
                    new MovieTheater{Room="A", MovieID=1},
                   new MovieTheater{Room="A", MovieID=2},
                   new MovieTheater{Room="B", MovieID=3}


                };
                context.MovieTheater.AddRange(movieTheater);
                context.SaveChanges();
                var tickets = new Ticket[]
               {
                new Ticket{MovieID =1, Amount =11, MovieTheaterID=1},
                new Ticket {MovieID =2, Amount =100, MovieTheaterID=2},
                new Ticket {MovieID =3, Amount =0, MovieTheaterID=3}

               };
                context.Ticket.AddRange(tickets);
                context.SaveChanges();
            }
        }


    }
}
