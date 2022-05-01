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
        public bool CheckTicketsLeft(int tickets, int id, bool flag)
        {

            var amountOfTickets = _context.Ticket
                .Where(m => m.Id == id)
                .Select(m => m.Amount)
                .First();
            var possibleTicketValue = amountOfTickets - tickets;
            if(possibleTicketValue < 0)
            {
                flag = true;
            }
            else
            {
            }
            return flag;

        }

        public async Task<IActionResult> OnPostAsync(int id)

        {
            bool flag=false;
            //Reducerar antalet biljetter
            var number = Request.Form["number"];
            var currentTickets = _context.Ticket
                .Where(m => m.Id == id)
                .Select(x => x.Amount)
                .First();
            int AmountToBuy = int.Parse(number);


           flag = CheckTicketsLeft(AmountToBuy, id, flag);
            if (flag == true)
            {
            }
            else
            {

                var newTicketValue = currentTickets - AmountToBuy;



                Tickets = await _context.Ticket
                  .Include(t => t.Movie).FirstOrDefaultAsync(m => m.Id == id);
                Tickets.Amount = newTicketValue;
                CurrentTickets = AmountToBuy;

                //Skickar det nya värdet till databasen
                _context.Attach(Tickets).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToPage("/Checkout");

            }
           return RedirectToPage("/Index");

        }
    }
}
