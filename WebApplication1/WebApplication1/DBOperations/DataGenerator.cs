using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using WebApplication1;

namespace BooksStore.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize (ServiceProvider serviceProvider)  
        {
            using (var context = new BookStoreDBContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDBContext>>()))
            {
                if (context.Books.Any()) 
                {
                    return;
                }

                context.AddRange(
                    new Book
                    {
                         Id = 1,
                         Title = "Uçurtma Avcısı",
                         GenreId = 1, //Roman 
                         PageCounter = 200,
                         PublishDate = new DateTime(2001, 06, 30)
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "Bozkurtlar",
                        GenreId = 2, //Tarih 
                        PageCounter = 600,
                        PublishDate = new DateTime(1924, 11, 22)
                    },
                    new Book
                    {
                        Id = 3,
                        Title = "Kürk Mantolu Madonna",
                        GenreId = 3, //Romantik
                        PageCounter = 380,
                        PublishDate = new DateTime(1961, 02, 15)
                    }
                );

                context.SaveChanges();
            }

        }
    }
}
