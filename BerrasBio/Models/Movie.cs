namespace BerrasBio.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
       public int Price { get; set; } = 0;
      public  int Minutes { get; set; } = 0;

        public List<Ticket> Tickets { get; set; } = new();
    }
}
