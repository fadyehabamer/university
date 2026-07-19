namespace Library.ViewModels
{
    public class BookVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }
    }
}
