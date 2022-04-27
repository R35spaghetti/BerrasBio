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
        private readonly BerrasBio.Models.MovieContext _context;

        public CurrentMoviesModel(BerrasBio.Models.MovieContext context)
        {
            _context = context;
        }

        public IList<Ticket> Ticket { get;set; }

        public async Task OnGetAsync()
        {
            Ticket = await _context.Tickets
                .Include(t => t.Movie).ToListAsync();
        }
    }
}
