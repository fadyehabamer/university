using Library.Data;
using Library.Models;
using Library.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks()
        {

                return _context.Books.ToList();

        }

        public Book GetBookById(int id)
        {

                return _context.Books.Find(id);

        }

        public List<Book> GetBookCategories()
        {
                return _context.Books.Include(b => b.Category).ToList();

        }

        public void CreateBook(Book book)
        {

            _context.Books.Add(book);
            _context.SaveChanges();

        }

        public void UpdateBook(Book book)
        {

            _context.Books.Update(book);
                _context.SaveChanges();

        }

        public void DeleteBook(int id)
        {
                var book = _context.Books.Find(id);
                _context.Books.Remove(book);
                _context.SaveChanges();

        }










    }
}
