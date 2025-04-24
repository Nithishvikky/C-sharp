using Microsoft.EntityFrameworkCore;
using Task10.Services;
using Task10.Data;

var builder = WebApplication.CreateBuilder(args);

// Add controller services
builder.Services.AddControllers();
// Add in-memory DB context
builder.Services.AddDbContext<AppDbContext>(options =>options.UseInMemoryDatabase("BooksDb"));
// Add service layers
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();
// Middlewares

// Ensures that you can control access with Authorize
app.UseAuthorization();
// Enable HTTPS redirection (important if you're using HTTP URL)
app.UseHttpsRedirection();
// Routes requests to the correct controller
app.MapControllers(); 
app.Run();
