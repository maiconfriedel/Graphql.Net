using System.ComponentModel.DataAnnotations;

namespace Graphql.Net.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }
    }
}
