using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BerrasBio.Models
{
    public class MovieTheater
    {   public int Id { get; set; }
        [Required]
        public string Room { get; set; } = string.Empty;
        [BindProperty]
        public Movie? Movie { get; set; }
        public Ticket? Ticket { get; set; }
    }
}
