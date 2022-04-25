namespace BerrasBio.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int Amount { get; set; }

        public Movie? Movie { get; set; }
        public int MovieID { get; set; }
    
    }
}
