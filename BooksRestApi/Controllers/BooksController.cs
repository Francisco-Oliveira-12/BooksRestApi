using BooksRestApi.Data;
using BooksRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BooksRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //static private List<Book> books = new List<Book>()
        //{
        //    new Book
        //    {
        //        Id = 1,
        //        Title = "Atomic Habits",
        //        Author = "James Clear",
        //        YearPublished = 2018
        //    },
        //    new Book
        //    {
        //        Id = 2,
        //        Title = "Deep Work",
        //        Author = "Cal Newport",
        //        YearPublished = 2016
        //    },
        //    new Book
        //    {
        //        Id = 3,
        //        Title = "The 7 Habits of Highly Effective People",
        //        Author = "Stephen R. Covey",
        //        YearPublished = 1989
        //    },
        //    new Book
        //    {
        //        Id = 4,
        //        Title = "Mindset",
        //        Author = "Carol S. Dweck",
        //        YearPublished = 2006
        //    }

        //};

        private readonly BooksRestApiContext _context;
        public BooksController(BooksRestApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all the books in the database in an async way.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            return Ok(await _context.Books.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book newBook)
        {
            if (newBook == null)
                return BadRequest(newBook);

            _context.Books.Add(newBook);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
        }

        //The return type is an IActionResult because it will only return status codes, not objects
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book updatedBook)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.YearPublished = updatedBook.YearPublished;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        //The return type is an IActionResult because it will only return status codes, not objects
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
