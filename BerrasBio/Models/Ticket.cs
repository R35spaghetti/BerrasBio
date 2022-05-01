using BerrasBio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BerrasBio.Models
{
    public class Ticket : ITicket
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Biljetter")]
        [Range(0,100)]
        public int Amount { get; set; }
        
        public Movie? Movie { get; set; }
        public MovieTheater? MovieTheater { get; set; }

        
        public int? MovieID { get; set; }
        public int? MovieTheaterID { get; set; }

    }
}
