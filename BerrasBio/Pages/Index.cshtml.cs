﻿#nullable disable
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

        public async Task OnGetAsync()
        {
            Ticket = await _context.Ticket
                .Include(t => t.Movie).ToListAsync();
        }
    }
}
