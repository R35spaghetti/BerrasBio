using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BerrasBio.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Amount of tickets")]
        public int Amount { get; set; }
        
        [BindProperty]
        public Movie? Movie { get; set; }
        [Required]
        public int MovieID { get; set; }
    
    }
}
