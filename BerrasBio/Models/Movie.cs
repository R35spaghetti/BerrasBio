using System.ComponentModel.DataAnnotations;

namespace BerrasBio.Models
{
    public class Movie
    {
         public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int Price { get; set; } = 0;
        [Required]
        public int Minutes { get; set; } = 0;
        [Required]
        public DateTime Date { get; set; } 

        //kanske ska vara i virtual?
        public ICollection<Ticket> Tickets { get; set; } //list innan
    }
}
