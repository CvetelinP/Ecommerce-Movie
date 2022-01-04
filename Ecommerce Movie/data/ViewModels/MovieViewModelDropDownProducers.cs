using Ecommerce_Movie.Models;

namespace Ecommerce_Movie.data.ViewModels
{
    public class MovieViewModelDropDownProducers
    {

        public MovieViewModelDropDownProducers()
        {
            Producers = new List<Producer>();
            Cinemas = new List<Cinema>();
            Actors = new List<Actor>();
        }
        public List<Producer> Producers { get; set; }

        public  List<Cinema>Cinemas { get; set; }

        public List<Actor> Actors { get; set; }
    }
}
