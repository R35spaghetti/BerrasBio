using BerrasBio.Models;
using BerrasBio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BerrasBio.Pages
{
    public class CartModel : PageModel
    {
        private readonly BerrasBio.Data.BerrasBioContext _context;
        public CartModel(BerrasBio.Data.BerrasBioContext context)
        {
            _context = context;
        }
        public SelectList TicketOptions { get; set; }
        
        //[BindProperty]
        //public Ticket TicketsInCart { get; set; }
        public Movie Movie { get; set; }
        public double Total { get; set; }

        //public async Task<IActionResult> OnPost()
        //{
        //  //  await DBInput.Add(TicketsInCart);
        //   await DbContext.SaveChangesAsync();
        //    return RedirectToPage("Index");
        //}
        public async Task<IActionResult> OnGetBuyTicketsAsync(int id)
        {
            if (id == null)
            {
                
                return NotFound();
            }

            Movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
            public void OnGet()
        {
            //Tar siffran från antal tickets
            var number = Request.Form["number"];

            //TODO: ta bort
            TicketOptions = new SelectList(_context.Ticket, nameof(Ticket.Amount));
        }
    }
}
