using Library.Data;
using Library.Models;
using Library.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
    public class BookRepository : IBookRepository
    {

        public List<Book> GetAllBooks()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Books.ToList();
            }
        }

        public Book GetBookById(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Books.Find(id);
            }
        }

        public List<Book> GetBookCategories()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Books.Include(b => b.Category).ToList();
            }
        }

        public void CreateBook(Book book)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Books.Add(book);
                context.SaveChanges();
            }
        }

        public void UpdateBook(Book book)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Books.Update(book);
                context.SaveChanges();
            }
        }

        public void DeleteBook(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var book = context.Books.Find(id);
                context.Books.Remove(book);
                context.SaveChanges();
            }
        }










    }
}
