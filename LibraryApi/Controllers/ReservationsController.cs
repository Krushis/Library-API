using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers
{
    /// <summary>
    /// Controller for reservations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly LibraryContext _context;

        public ReservationsController(LibraryContext context)
        {
            _context = context;
        }

        [HttpPost("reserve")]
        public async Task<IActionResult> ReserveBook([FromBody] ReserveRequest request)
        {
           
            var book = await _context.Books.FindAsync(request.BookId);
            if (book == null || !book.AvailableFormats.Contains(request.Type))
            {
                return BadRequest("Book not available in the specified format.");
            }

            
            var user = await _context.Users.FindAsync(request.UserId); // Later wanted to add functionality
                                                                       // for users to register and login and
                                                                       // only allow them to reserve when logged in
                                                                       // but this part just checks if the requests user
                                                                       // is still registered in the users database
            if (user == null)
            {
                return NotFound("User not found.");
            }

            
            var reservation = new Reservation(
                Guid.NewGuid().ToString(),
                request.BookId,
                request.UserId,
                request.Type,
                request.QuickPickUp,
                request.DaysReserved
            );

            {
                reservation.Book = book;
            }

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ReserveBook), new { id = reservation.Id }, reservation);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservedBooks()
        {
            
            var reservedBooks = await _context.Reservations
                .Include(r => r.Book) // had lots of questions on what is the best way to do this part, since
                // the Reservation.cs file comments a bit about it (the virtual part), but I wasn't sure if this
                // is efficient
                .ToListAsync();

            if (reservedBooks == null || !reservedBooks.Any())
            {
                return NotFound();
            }

            return Ok(reservedBooks);
        }

    }
}
