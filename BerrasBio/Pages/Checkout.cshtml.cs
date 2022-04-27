using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BerrasBio.Models;
using BerrasBio.Data;
using BerrasBio.Pages;
using Microsoft.EntityFrameworkCore;

namespace BerrasBio.Pages
{
    public class CheckoutModel : PageModel
    {
        private readonly BerrasBio.Data.BerrasBioContext _context;
     
        public Movie Movie { get; set; }
        public Ticket Tickets { get; set; }
        public double Total { get; set; }
        public int BoughtTickets { get; set; }


        public void OnGet()
        {
    

            
        }
    }
}
