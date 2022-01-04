using System.ComponentModel.DataAnnotations;
using Ecommerce_Movie.data.Base;

namespace Ecommerce_Movie.Models
{
    public class Cinema:IEntityBase
    {

        [Key]
        public int Id { get; set; }

        [Required]

        public string Logo { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }


        public List<Movie> Movies { get; set; }

    }
}
