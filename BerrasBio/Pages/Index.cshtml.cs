#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BerrasBio.Models;

namespace BerrasBio.Pages.ShowAllMovies
{
    public class CurrentMoviesModel : PageModel
    {
        private readonly BerrasBio.Data.BerrasBioContext _context;

        public CurrentMoviesModel(BerrasBio.Data.BerrasBioContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Movie Movie { get; set; }
        public IList<Ticket> Ticket { get;set; }
        public  IList<MovieTheater> Theater { get; set; }
      
        public string DateSort { get; set; }
        public string TicketsLeftSort { get; set; }
       
        public IList<Ticket> Tickets { get; set; }
       
        public async Task OnGetAsync (string sortOrder)
        {


            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            TicketsLeftSort = sortOrder == "Amount" ? "Amount_desc" : "Amount";


            IQueryable<Ticket> TicketsIQ = from x in _context.Ticket select x;

  

            switch (sortOrder)
            {
                case "Date":
                    TicketsIQ = TicketsIQ.OrderBy(x => x.Movie.Date);

                    break;
                case "date_desc":
                    TicketsIQ = TicketsIQ.OrderByDescending(x=>x.Movie.Date);
                    break;
                case "Amount":
                    TicketsIQ = TicketsIQ.OrderBy (x => x.Amount);

                    break;

                case "Amount_desc":
                    TicketsIQ = TicketsIQ.OrderByDescending(x => x.Amount);

                    break;
            }
            Tickets = await  TicketsIQ.AsNoTracking().Include(t=>t.Movie).Include(t=>t.MovieTheater).ToListAsync();
            Ticket = await _context.Ticket
             .Include(t => t.Movie).Include(t=>t.MovieTheater).ToListAsync();
        }
    }
}
/*TODO: två salonger
interfaces
 */