using Microsoft.AspNetCore.Mvc;
using PracticeTest.Entities;
using PracticeTest.Service;

namespace PracticeTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            try
            {
                _bookService.AddBook(book);
                return StatusCode(201, "Book created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating book: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _bookService.GetAllBooks();
                return StatusCode(200, books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting books: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            try
            {
                var book = _bookService.GetBookById(id);

                if (book == null)
                {
                    return NotFound($"Book with ID {id} not found.");
                }

                return StatusCode(200, book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error getting book: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            try
            {
                var existingBook = _bookService.GetBookById(id);

                if (existingBook == null)
                {
                    return NotFound($"Book with ID {id} not found.");
                }

                existingBook.title = book.title;
                existingBook.author = book.author;
                existingBook.genre = book.genre;
                existingBook.ISBN = book.ISBN;
                existingBook.PublishDate = book.PublishDate;

                _bookService.UpdateBook(existingBook);
                return StatusCode(200, "Book updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating book: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                var existingBook = _bookService.GetBookById(id);

                if (existingBook == null)
                {
                    return NotFound($"Book with ID {id} not found.");
                }

                _bookService.DeleteBook(id);
                return StatusCode(200, "Book deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting book: {ex.Message}");
            }
        }
    }
}
