using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BerrasBio.Models
{
    public class MovieTheater

    {
        public int Id { get; set; }
        public string Room { get; set; } = string.Empty;
        [Required]
        public Movie? Movie { get; set; }
        [Required]
        public int MovieID { get; set; }

    }
}
