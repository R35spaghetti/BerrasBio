#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BerrasBio.Data;
using BerrasBio.Models;

namespace BerrasBio.Pages.Admin.AdminTickets
{
    public class CreateModel : PageModel
    {
        private readonly BerrasBio.Data.BerrasBioContext _context;

        public CreateModel(BerrasBio.Data.BerrasBioContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MovieID"] = new SelectList(_context.Movie, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Ticket Ticket { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ticket.Add(Ticket);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
