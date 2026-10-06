using BooksRestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        static private List<Book> books = new List<Book>()
        {
            new Book
            {
                Id = 1,
                Title = "Atomic Habits",
                Author = "James Clear",
                YearPublished = 2018
            },
            new Book
            {
                Id = 2,
                Title = "Deep Work",
                Author = "Cal Newport",
                YearPublished = 2016
            },
            new Book
            {
                Id = 3,
                Title = "The 7 Habits of Highly Effective People",
                Author = "Stephen R. Covey",
                YearPublished = 1989
            },
            new Book
            {
                Id = 4,
                Title = "Mindset",
                Author = "Carol S. Dweck",
                YearPublished = 2006
            }

        };

        [HttpGet]
        public ActionResult<List<Book>> GetBooks()
        {
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if(book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
    }
}
