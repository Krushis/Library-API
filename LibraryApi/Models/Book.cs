using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models
{
    /// <summary>
    /// Book class
    /// </summary>
    public class Book
    {
        [Key]
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required int Year { get; set; }
        public required List<string> AvailableFormats { get; set; } = new List<string>(); // "Book", "Audiobook" or one of them
        public required string ImagePath { get; set; }


    }
}
