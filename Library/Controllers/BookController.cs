using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController()
        {
            _bookService = new BookService();
        }

        [HttpGet]
        public IActionResult GetAllBooks() => Ok(_bookService.GetAllBooks());

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null) return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            _bookService.AddBook(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveBook(int id)
        {
            if (_bookService.RemoveBook(id)) return NoContent();

            return NotFound();
        }

        [HttpPost("{id}/rent")]
        public IActionResult RentBook(int id)
        {
            if (_bookService.RentBook(id)) return Ok();

            return BadRequest("Book is unavailable.");
        }

        [HttpPost("donate")]
        public IActionResult DonateBook([FromBody] Book book)
        {
            _bookService.DonateBook(book);
            return Ok();
        }
    }
}
