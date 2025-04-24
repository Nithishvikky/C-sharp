using Microsoft.EntityFrameworkCore;
using Task10.Models;
using Task10.Data;

namespace Task10.Services{
    public class BookService : IBookService{
        private readonly AppDbContext _context;
        public BookService(AppDbContext c){
            _context = c;
        }
        public async Task<IEnumerable<Book>> GetAllBooksAsync(){
            var AllBooks = await _context.Books.ToListAsync();
            return AllBooks;
        }
        public async Task<Book> GetBookByIdAsync(int id){
            var book = await _context.Books.FindAsync(id);
            return book;
        }
        public async Task AddBookAsync(Book b) {
            _context.Books.Add(b);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateBookAsync(int id, Book b){
            if(id!=b.Id) throw new ArgumentException("Id mismatch");
            var ebook = await _context.Books.FindAsync(id);
            if(ebook == null) throw new KeyNotFoundException("There is no book like this");

            _context.Entry(ebook).CurrentValues.SetValues(b);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id){
            var book = await _context.Books.FindAsync(id);
            if(book == null)  throw new KeyNotFoundException("There is no book like this");
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}