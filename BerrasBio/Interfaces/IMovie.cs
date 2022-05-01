
namespace BerrasBio.Interfaces
{
    public interface IMovie
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Minutes { get; set; }
        public DateTime Date { get; set; }

    }
}
