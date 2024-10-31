using Microsoft.AspNetCore.Mvc;
using LibraryApi.Data;
using LibraryApi.Models;

namespace LibraryApi.Controllers
{
    /// <summary>
    /// Controller for books
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;

            
            if (!_context.Books.Any()) // this is where I started to test out my backend
            {
                _context.Books.Add(new Book { Id = "FT689", Name = "Sample Book", Year = 2022, AvailableFormats = new List<string> { "Book", "Audiobook" }, ImagePath = "/images/sample.jpg" });
                _context.SaveChanges();
            }
        }

        // Tried using cURL to test the Http requests at the start of building the backend

        // api/books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return Ok(_context.Books.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = _context.Books.Find(id);
            return book == null ? NotFound() : Ok(book);
        }

        // api/books/id
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id) // important to note that its good idea only for admins
                                               // to use this controller  or to use it
                                               // for client's personal library list, so he can remove sth from it
                                               // have to add this functionality later :(
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            _context.SaveChanges();

            return NoContent();
        }


        // api/books
        [HttpPost]
        public ActionResult<Book> CreateBook([FromBody] Book book) // also mostly intended for admins, but am starting to think
            // that this is not needed, since you can just add the book into the actual database by hand no?
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetBooks), new { id = book.Id }, book);
        }


    }
}
