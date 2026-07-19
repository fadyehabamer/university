using Library.Models;

namespace Library.Repository.IRepository
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        List<Book> GetBookCategories();
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);


    }
}
