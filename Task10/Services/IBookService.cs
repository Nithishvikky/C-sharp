using Task10.Models;

public interface IBookService
{
        Task<IEnumerable<Book>> GetAllBooksAsync();//Returns all books
        Task<Book?> GetBookByIdAsync(int id);//Return one or null
        Task AddBookAsync(Book book);//True if added
        Task UpdateBookAsync(int id, Book book);//True if updated
        Task DeleteBookAsync(int id);// True if deleted
}