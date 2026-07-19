using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Library.ViewModels;
using Library.Data;
using Microsoft.EntityFrameworkCore;
using Library.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Library.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
namespace Library.Controllers

{
    public class BookController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        //BookRepository bookRepository = new BookRepository();
        //CategoryRepository categoryRepository = new CategoryRepository();

        IBookRepository bookRepository;
        ICategoryRepository categoryRepository;

        public BookController(IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            this.bookRepository = bookRepository;
            this.categoryRepository = categoryRepository;
        }


        //    public IActionResult Index()
        //    {
        //        // var listOfBooks = context.Books.Include(b => b.Category).ToList();
        //        // Repository pattern
        //        var listOfBooks = bookRepository.GetBookCategories();
        //        return View(listOfBooks);
        //    }

        //    public IActionResult Create()
        //    {
        //        //ViewBag.Categories = context.Categories.ToList();
        //        //Repository pattern
        //        ViewBag.Categories = categoryRepository.GetAllCategories();

        //        return View();
        //    }

        //    [HttpPost]
        //    public IActionResult Create(BookVM bookVm)
        //    {
        //        Book NewBook = new Book()
        //        {
        //            Name = bookVm.Name,
        //            Description = bookVm.Description,
        //            Author = bookVm.Author,
        //            CategoryId = bookVm.CategoryId
        //        };

        //        if (ModelState.IsValid)
        //        {
        //            // Save book to
        //            //context.Books.Add(NewBook);
        //            //context.SaveChanges();

        //            // Repository pattern
        //            bookRepository.CreateBook(NewBook);

        //            return RedirectToAction("Index");
        //        }

        //        return View();

        //    }


        //    public IActionResult Edit(int id)
        //    {
        //        //ViewBag.Categories = context.Categories.ToList();

        //        //Repository pattern
        //        ViewBag.Categories = categoryRepository.GetAllCategories();


        //        //var book = context.Books.Find(id);


        //        // repository pattern
        //        var book = bookRepository.GetBookById(id);


        //        return View(book);
        //    }

        //    [HttpPost]
        //    public IActionResult Edit(BookVM bookVm)
        //    {
        //        Book book = new Book()
        //        {
        //            ISBN = bookVm.Id,
        //            Name = bookVm.Name,
        //            Description = bookVm.Description,
        //            Author = bookVm.Author,
        //            CategoryId = bookVm.CategoryId
        //        };

        //        if (ModelState.IsValid)
        //        {
        //            //context.Books.Update(book);
        //            //context.SaveChanges();

        //            //Repository pattern
        //            bookRepository.UpdateBook(book);

        //            return RedirectToAction("Index");
        //        }

        //        return View();
        //    }

        //    public IActionResult Delete(int id)
        //    {
        //        //var book = context.Books.Find(id);
        //        var book = bookRepository.GetBookById(id);

        //        return View(book);
        //    }

        //    [HttpPost]
        //    public IActionResult ConfirmDelete(int ISBN)
        //    {
        //        //var book = context.Books.Find(ISBN);
        //        //Repository pattern
        //        var book = bookRepository.GetBookById(ISBN);

        //        //context.Books.Remove(book);
        //        //context.SaveChanges();

        //        // Repository pattern
        //        bookRepository.DeleteBook(ISBN);

        //        return RedirectToAction("Index");
        //    }




        //}

        [AllowAnonymous]
        public IActionResult Index()
        {
            var listOfBooks = bookRepository.GetBookCategories();
            return View(listOfBooks);
        }
        [Authorize]

        public IActionResult Create()
        {
            // ViewBag.Categories = categoryRepository.GetAllCategories();

            // We can cast here
            ViewBag.Categories = categoryRepository.GetAllCategories()
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList();

            return View();
        }
        [Authorize]

        [HttpPost]
        public IActionResult Create(BookVM bookVM)
        {
            Book book = new Book()
            {
                Name = bookVM.Name,
                Description = bookVM.Description,
                Author = bookVM.Author,
                CategoryId = bookVM.CategoryId
            };

            if (ModelState.IsValid)
            {
                bookRepository.CreateBook(book);
                return RedirectToAction("Index");
            }

            return View();
        }
        [Authorize]

        public IActionResult Edit(int id)
        {
            ViewBag.Categories = categoryRepository.GetAllCategories();
            var book = bookRepository.GetBookById(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(BookVM bookVM)
        {
            Book book = new Book()
            {
                ISBN = bookVM.Id,
                Name = bookVM.Name,
                Description = bookVM.Description,
                Author = bookVM.Author,
                CategoryId = bookVM.CategoryId
            };

            if (ModelState.IsValid)
            {
                bookRepository.UpdateBook(book);
                return RedirectToAction("Index");
            }

            return View();
        }
        [Authorize]

        public IActionResult Delete(int id)
        {
            var book = bookRepository.GetBookById(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int ISBN)
        {
            var book = bookRepository.GetBookById(ISBN);
            bookRepository.DeleteBook(ISBN);
            return RedirectToAction("Index");
        }
    }
}

