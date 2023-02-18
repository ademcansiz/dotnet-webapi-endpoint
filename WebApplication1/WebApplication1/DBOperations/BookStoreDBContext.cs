using Microsoft.EntityFrameworkCore;
using WebApplication1;

namespace BooksStore.DBOperations
{
    public class BookStoreDBContext:DbContext
    {
     public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options):base(options)
        {

        }
        public DbSet<Book> Books { get; set; }  
    }
}
