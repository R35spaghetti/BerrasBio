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
        public Ticket Tickets { get; set; }
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


            //TicketOptions = new SelectList(_context.Ticket, nameof(Ticket.Amount));
        }


        public async Task<IActionResult> OnPostAsync(int id)
                
        {
          var  number = Request.Form["number"];
            var currentTickets = _context.Ticket
                .Select(x => x.Amount)
                .First();
           int number2 = int.Parse(number);
            var newTicketValue = currentTickets - number2;
            Tickets = await _context.Ticket
              .Include(t => t.Movie).FirstOrDefaultAsync(m => m.Id == id);
            Tickets.Amount = newTicketValue;
            //Tar siffran från antal tickets
            _context.Attach(Tickets).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

        }
    }
}
