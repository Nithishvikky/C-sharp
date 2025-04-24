using Microsoft.AspNetCore.Mvc;
using Task10.Models;

namespace Task10.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;
        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookService s,ILogger<BooksController> l){
            _service = s;
            _logger = l;
        }

        // GET:api/books
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            _logger.LogInformation("Fetching all book details...");
            var ListOfBooks = await _service.GetAllBooksAsync();

            if(!ListOfBooks.Any()){ 
                _logger.LogWarning("No books found in the collection");
                return NotFound("There are no books");
            }
            
            _logger.LogInformation($"Fetched {ListOfBooks.Count()} books");
            return Ok(ListOfBooks);
        }

        // GET:api/books/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id){
            
            _logger.LogInformation($"Fetching book with ID {id}...");
            var book = await _service.GetBookByIdAsync(id);

            if(book == null){
                _logger.LogWarning($"Book with ID {id} not found");
                return NotFound("Book not found");
            }

            _logger.LogInformation($"Book with ID {id} fetched successfully");
            return Ok(book);
        }

        // POST:api/books
        [HttpPost]
        public async Task<IActionResult> AddBook(Book b){
             if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid book data received");
                return BadRequest(ModelState);
            }
            await _service.AddBookAsync(b);
            _logger.LogInformation("Book added successfully");
            return Ok("Book Added");
        }

        // PUT:api/books/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id,Book b){
            try
            {
                await _service.UpdateBookAsync(id, b);
                _logger.LogInformation($"Book with ID {id} updated");
                return Ok("Updated successfully");
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex.Message);
                return NotFound(ex.Message);
            }
        }

        // DELETE:api/books/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id){
            try{
                await _service.DeleteBookAsync(id);
                _logger.LogInformation($"Book with ID {id} deleted successfully");
                return Ok("Deleted successfully");
            }
            catch (KeyNotFoundException ex){
                _logger.LogWarning(ex.Message);
                return NotFound(ex.Message);
            }
            
        }
    }
}