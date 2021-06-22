using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class BookModel : IEntityBase
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Category { get; set; }

        public int? ReaderId { get; set; }

        public string FreeDate { get; set; }

        public string EliminationDate { get; set; }
    }
}
