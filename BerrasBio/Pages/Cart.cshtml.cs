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

        //TODO antingen få välja biljetter samtidigt som du väljer film men hur skickar man in i det i databasen?
        public Movie Movie { get; set; }
        public Ticket Tickets { get; set; }

        public double TotalCost { get; set; }
        public int CurrentTickets { get; set; }


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
        public IList<Ticket> Ticket { get; set; }

        public void OnGet()
        {
           
        }

        ////Id tappas när det blir asp-page-handler="AsyncCalculate"
        //public async Task OnPost(int id)

        //{
        //    //Beräkna kostnaden av biljetter
        //    var number = Request.Form["number"];
           
        //    int number2 = int.Parse(number);
     

        //    //Räknar ut totala priset
        //    var priceOnMovie =  _context.Movie
        //        .Where(m => m.Id == id)
        //         .Select(x => x.Price)
        //        .First();
        //    TotalCost = priceOnMovie * number2;
        //    CurrentTickets = number2;
        

        //}

        public async Task<IActionResult> OnPostAsync(int id)

        {
            //Reducerar antalet biljetter
            var number = Request.Form["number"];
            var currentTickets = _context.Ticket
                .Where(m => m.Id == id)
                .Select(x => x.Amount)
                .First();
            int number2 = int.Parse(number);
            var newTicketValue = currentTickets - number2;
            Tickets = await _context.Ticket
              .Include(t => t.Movie).FirstOrDefaultAsync(m => m.Id == id);
            Tickets.Amount = newTicketValue;
            CurrentTickets = number2;

            //Skickar det nya värdet till databasen
            _context.Attach(Tickets).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("/Checkout");
        }
    }
}
