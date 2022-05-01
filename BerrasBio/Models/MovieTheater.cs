using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BerrasBio.Models
{
    public class MovieTheater

    {
        public int Id { get; set; }
        public string Room { get; set; } = string.Empty;
        
        public Movie? Movie { get; set; }
        public Ticket? Ticket { get; set; }
        
        public int MovieID { get; set; }
    }
}
