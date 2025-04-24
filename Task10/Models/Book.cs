using System.ComponentModel.DataAnnotations;

// it's like tag used for group the code
namespace Task10.Models
{
    public class Book
    {
        public int Id { get; set; } // Primary Key
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public int Year { get; set; }
    }
}