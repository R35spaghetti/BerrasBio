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

        //public async Task OnGetAsync()
        //{
        
        //}
        public string DateSort { get; set; }
        public string TicketsLeftSort { get; set; }
       
        public IList<Ticket> Tickets { get; set; }
       
        public async Task OnGetAsync (string sortOrder)
        {


            DateSort = sortOrder == "Date" ? "date_Movie" : "Date";
            TicketsLeftSort = sortOrder == "Amount" ? "Amount_Left" : "Amount";


            IQueryable<Ticket> TicketsIQ = from x in _context.Ticket select x;

  

            switch (sortOrder)
            {
                case "Date":
                    TicketsIQ = TicketsIQ.OrderBy(x => x.Movie.Date);

                    break;
                case "date_Movie":
                    TicketsIQ = TicketsIQ.OrderByDescending(x=>x.Movie.Date);
                    break;
                case "Amount":
                    TicketsIQ = TicketsIQ.OrderBy (x => x.Amount);

                    break;

                case "Amount_Left":
                    TicketsIQ = TicketsIQ.OrderByDescending(x => x.Amount);

                    break;
            }
            Tickets = await  TicketsIQ.AsNoTracking().Include(t=>t.Movie).ToListAsync();
            Ticket = await _context.Ticket
             .Include(t => t.Movie).ToListAsync();
        }
    }
}
/*TODO: två salonger
sortera på visningstid och platser kvar
interfaces
 */