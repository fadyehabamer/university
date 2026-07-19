using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public int ISBN { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; }
        public string Author { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
