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
            { context.Database.EnsureCreated(); 
                if (context.Movie.Any())
                {
                    return;
                }
                var movies = new Movie[]
                {
                    new Movie{Name = "Glen i Göteborg", Minutes = 60, Price = 30, Date= new DateTime(2022,04,30,11,30,45) },
                    new Movie{Name = "Den där", Minutes=50, Price = 20, Date= new DateTime(2022,04,30,10,30,45), },
                          new Movie{Name = "Populär film", Minutes=50, Price = 60, Date= new DateTime(2022,04,30,12,30,45), },
                            new Movie{Name = "Glen i Stockholm", Minutes = 60, Price = 56, Date= new DateTime(2022,04,30,13,30,00) },
                    new Movie{Name = "Ännu en långfilm", Minutes=50, Price = 35, Date= new DateTime(2022,04,30,14,10,00), },
                          new Movie{Name = "En Kortfilm", Minutes=20, Price = 10, Date= new DateTime(2022,04,30,14,30,00), }
                };
                context.Movie.AddRange(movies);
                context.SaveChanges();

               

                var movieTheater = new MovieTheater[]
                {
                    new MovieTheater{Room="A", MovieID=1},
                   new MovieTheater{Room="A", MovieID=2},
                   new MovieTheater{Room="B", MovieID=3},
                      new MovieTheater{Room="B", MovieID=4},
                   new MovieTheater{Room="A", MovieID=5},
                   new MovieTheater{Room="B", MovieID=6}


                };
                context.MovieTheater.AddRange(movieTheater);
                context.SaveChanges();
                var tickets = new Ticket[]
               {
                new Ticket{MovieID =1, Amount =11, MovieTheaterID=1},
                new Ticket {MovieID =2, Amount =30, MovieTheaterID=2},
                new Ticket {MovieID =3, Amount =0, MovieTheaterID=3},
                    new Ticket{MovieID =4, Amount =50, MovieTheaterID=4},
                new Ticket {MovieID =5, Amount =40, MovieTheaterID=5},
                new Ticket {MovieID =6, Amount =100, MovieTheaterID=6}

               };
                context.Ticket.AddRange(tickets);
                context.SaveChanges();
            }
        }


    }
}
