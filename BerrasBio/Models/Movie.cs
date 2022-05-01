using BerrasBio.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BerrasBio.Models
{
    public class Movie : IMovie
    {
         public int Id { get; set; }
        [Required]
        [DisplayName("Film")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [DisplayName("Pris")]
        public int Price { get; set; } = 0;
        [Required]
        [DisplayName("Minuter")]
        public int Minutes { get; set; } = 0;
        [Required]
        [DisplayName("Datum")]
        public DateTime Date { get; set; }

        public virtual Ticket Tickets { get; set; }
        public virtual MovieTheater Theaters { get; set; }
       
    }
}
