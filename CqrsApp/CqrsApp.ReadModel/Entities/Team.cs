using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CqrsApp.ReadModel.Entities
{
    public class Team
    {
        public Team()
        {
            this.Players = new List<Player>();
        }
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Image Source")]
        public string ImageUrl { get; set; }
        public virtual List<Player> Players { get; set; }
    }
}
