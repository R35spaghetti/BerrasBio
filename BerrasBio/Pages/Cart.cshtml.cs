using BerrasBio.Models;
using BerrasBio.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BerrasBio.Pages
{
    public class CartModel : PageModel
    {
        private readonly BerrasBio.Data.BerrasBioContext _context;
        public CartModel(BerrasBio.Data.BerrasBioContext context)
        {
            _context = context;
        }
        public IQueryable<Ticket>? TicketsInCart { get; set; }
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
        }
    }
}
