using System;
using System.ComponentModel.DataAnnotations;

namespace CqrsApp.Models
{
    public class PlayerViewModel
    {
        public Guid PlayerId { get; set; }
        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Please enter correct number. Value for {0} must be between {1} and {2}.")]
        public int PlayerNumber { get; set; }
        [Required(ErrorMessage = "Please enter a surname.")]
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        [Range(7, 40, ErrorMessage = "Please enter correct age. Value for {0} must be between {1} and {2}.")]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Date of Birthday")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DayBirth { get; set; }
        [Required(ErrorMessage = "Please enter country.")]
        public string Country { get; set; }
        public Guid? TeamId { get; set; }
        public bool ShouldUploadAvatarFromDisk { get; set; } = false;
        public bool IsEdit { get; set; } = false;
        public string DefaultImg { get; set; } = "//placehold.it/100";
    }
}