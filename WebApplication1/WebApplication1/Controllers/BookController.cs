using BooksStore.DBOperations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        /*     private readonly BookStoreDBContext _context;

             public BookController(BookStoreDBContext context)
             {
                 _context
             }*/

        private static List<Book> BookList = new List<Book>() {
            new Book
            {
                Id=1,
                Title = "Uçurtma Avcısı",
                GenreId=1, //Roman 
                PageCounter = 200,
                PublishDate = new DateTime(2001,06,30)
            },
            new Book
            {
                Id=2,
                Title = "Bozkurtlar",
                GenreId=2, //Tarih 
                PageCounter = 600,
                PublishDate = new DateTime(1924,11,22)
            },
            new Book
            {
                Id=3,
                Title = "Kürk Mantolu Madonna",
                GenreId=3, //Romantik
                PageCounter = 380,
                PublishDate = new DateTime(1961,02,15)
            }
        };

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(x => x.Id).ToList<Book>();
            return bookList;
        }
        /*        public IActionResult GetBooks()
        {
            var bookList = BookList.OrderBy(x => x.Id).ToList<Book>();
            return new ObjectResult(null) { StatusCode = 204 };
        }*/

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = BookList.Where(book => book.Id == id).SingleOrDefault();
            return book;
        }

        /*        [HttpGet]
                public Book Get([FromQuery]String id)
                {
                    var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
                    return book;
                }*/

        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = BookList.SingleOrDefault(x => x.Title == newBook.Title);

            if (book != null)
            {
                return BadRequest();
            }

            BookList.Add(newBook);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = BookList.SingleOrDefault(x=> x.Id == id);
            if (book is null)
            {
                return BadRequest();
            }

            book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
            book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
            book.PageCounter = updatedBook.PageCounter != default ? updatedBook.PageCounter : book.PageCounter;
            book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id) {

            var book = BookList.SingleOrDefault(x => x.Id == id);
            if (book is null) {
                return BadRequest();
            }
            BookList.Remove(book);
            return Ok();
        }    
    }
}
