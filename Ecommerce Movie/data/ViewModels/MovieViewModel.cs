using System.ComponentModel.DataAnnotations;
using Ecommerce_Movie.Models.Enum;

namespace Ecommerce_Movie.data.ViewModels
{
    public class MovieViewModel
    {

        public int  Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [Display(Description = "Movie name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Display(Description = "Description movie")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Price is required")]
        [Display(Description = "Movie price")]
        public double Price { get; set; }


        [Required(ErrorMessage = "Image is required")]
        [Display(Description = "Movie poster Url")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        [Display(Description = "Start Date")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End Date is required")]
        [Display(Description = "End Date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Movie Category  is required")]
        [Display(Description = "Select categories")]
        public MovieCategory MovieCategory { get; set; }

        [Required(ErrorMessage = "Actors List  is required")]
        [Display(Description = "Select a actor")]
        public List<int> ActorIds { get; set; }

        [Required(ErrorMessage = "Cinema   is required")]
        [Display(Description = "Select cinemas")]
        public int CinemaId { get; set; }

        public int ProducerId { get; set; }
       
    }
}
