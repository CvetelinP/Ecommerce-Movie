using System.ComponentModel.DataAnnotations;
using Ecommerce_Movie.data.Base;

namespace Ecommerce_Movie.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture Url")]
        [Required(ErrorMessage = "Profiled Picture is required")]
        public string ProfilePictureUrl { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Name is required !")]
        public string FullName { get; set; }
        [Display(Name = "Bio")]
        [Required(ErrorMessage = "Biography is required !")]
        public string Bio { get; set; }

        //Relationships


        public List<Movie> Movies { get; set; }
    }
}
