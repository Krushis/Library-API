using LibraryApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace LibraryApi.Data
{
    /// <summary>
    /// Seeds data into the in-memory database
    /// </summary>
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                
                if (context.Books.Any())
                {
                    return;
                }
                
                
                context.Books.AddRange(
                    new Book { Id = "FT689", Name = "The Hitchhiker's Guide to the Galaxy", Year = 1979, AvailableFormats = new List<string> { "Book"}, ImagePath = "book1.jpg" },
                    new Book { Id = "FT690", Name = "The Adventure's of Tom Sawyer", Year = 1876, AvailableFormats = new List<string> { "Book", "Audiobook" }, ImagePath = "tom2.jpg" },
                    new Book { Id = "AB324", Name = "Dune", Year = 1965, AvailableFormats = new List<string> { "Audiobook" }, ImagePath = "dune.jpg" }
                );

                context.Users.AddRange(
                    new User { Id = 1, UserName = "Matas Mataitis", Password = "abcdefg"}
                    );

                context.SaveChanges();
            }
        }
    }
}
