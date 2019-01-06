using System;
using System.ComponentModel.DataAnnotations;

namespace CqrsApp.ReadModel.Entities
{
    public class Player : Person
    {
        [Required(ErrorMessage = "Please enter a player number")]
        public int PlayerNumber { get; set; }
        [Required(ErrorMessage = "Please enter a country")]
        public string Country { get; set; }
        public DateTime? DayBirth { get; set; }
        public string ImageUrl { get; set; }
        public virtual Team Team { get; set; }
    }
}
